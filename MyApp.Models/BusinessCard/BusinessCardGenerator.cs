using MyApp.Dependencies;
using MyApp.Models.Application;
using MyApp.Services.BusinessCard;
using Splat;
using System;
using System.Diagnostics;
using System.IO;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;

namespace MyApp.Models.BusinessCard
{
    public class BusinessCardGenerator : ModelBase
    {
        public BusinessCardGenerator(ModelState model) : base(model)
        {
        }

        protected override void HandleActivation(CompositeDisposable d)
        {
            Model.Bus.Listen<GenerateRequest>()
                .ObserveOn(ThreadPoolScheduler.Instance)
                .Subscribe(Generate)
                .DisposeWith(d);

            Model.Bus.Listen<InitializeRequest>()
                .Subscribe(Initialize)
                .DisposeWith(d);
        }

        protected virtual void Generate(GenerateRequest request)
        {
            string result = null;
            try
            {
                Thread.Sleep(2000);
                var pdfData = Locator.Current.GetService<IBusinessCardService>()
                    .GeneratePDF(new GenerateParameter()
                    {
                        Name = request.Name,
                        Organization = request.Organization
                    })
                    .Result;
                var filePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                    Path.GetTempFileName());
                File.WriteAllBytes(filePath, pdfData);
                result = filePath;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Locator.Current.GetService<IMessageDialog>()
                    .ShowAlertMessage("Generation error", ex.Message, () =>
                    {
                        result = ex.Message;
                    });
            }

            Model.Bus.SendMessage(new GenerateResponse() { Result = result });
        }

        protected virtual void Initialize(InitializeRequest request)
        {
            Model.Bus.SendMessage(new InitializeResponse());
        }
    }
}
