using MyApp.Dependencies;
using MyApp.Services.BusinessCard;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyApp.ViewModel
{
    public class HomeViewModel: RoutableViewModel
    {
        [Reactive]
        public string Name { get; set; }

        [Reactive]
        public string Organization { get; set; }

        public ICommand SubmitCommand { get; }

        public HomeViewModel(IScreen hostScreen) : base(hostScreen)
        {
            SubmitCommand = ReactiveCommand.CreateFromTask(ProcessSubmit);
        }

        private async Task ProcessSubmit()
        {
            string result = null;
            try
            {
                result = await Task.Run(async () =>
                {
                    var pdfData = await Locator.Current.GetService<IBusinessCardService>()
                        .GeneratePDF(new GenerateParameter()
                        {
                            Name = Name,
                            Organization = Organization
                        });
                    var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Path.GetTempFileName());
                    File.WriteAllBytes(filePath, pdfData);
                    Debug.WriteLine(filePath);
                    return filePath;
                });
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

            HostScreen.Router.Navigate.Execute(new ResultViewModel(HostScreen)
            {
                Name = Name,
                Organization = Organization,
                Result = result
            }).Subscribe();
        }
    }
}
