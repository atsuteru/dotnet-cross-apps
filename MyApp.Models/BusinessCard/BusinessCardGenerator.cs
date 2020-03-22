using MyApp.Dependencies;
using MyApp.Models.Application;
using MyApp.Services.BusinessCard;
using Splat;
using System;
using System.Diagnostics;
using System.IO;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace MyApp.Models.BusinessCard
{
    public class BusinessCardGenerator : RouteModelBase
    {
        public BusinessCardGenerator(IModelHost host) : base(host)
        {
        }

        public IObservable<GenerateResponse> Generate(GenerateRequest request)
        {
            return Observable
                .FromAsync(() => GenerateAsync(request))
                .SubscribeOn(ThreadPoolScheduler.Instance);
        }

        protected virtual Task<GenerateResponse> GenerateAsync(GenerateRequest request)
        {
            string result = null;
            try
            {
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

            return Task.FromResult(new GenerateResponse() { Result = result });
        }

        public IObservable<InitializeResponse> Initialize(InitializeRequest request)
        {
            return Observable
                .FromAsync(() => InitializeAsync(request));
        }

        protected virtual Task<InitializeResponse> InitializeAsync(InitializeRequest request)
        {
            return Task.FromResult(new InitializeResponse());
        }
    }
}
