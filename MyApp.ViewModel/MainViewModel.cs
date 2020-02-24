using MyApp.Model.BusinessCard;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Unity;

namespace MyApp.ViewModel
{
    public class MainViewModel: ReactiveObject
    {

        [Reactive]
        public string Name { get; set; }

        [Reactive]
        public string Organization { get; set; }

        public ICommand SubmitCommand { private set; get; }

        public MainViewModel()
        {
            SubmitCommand = ReactiveCommand.CreateFromTask(ProcessSubmit);
        }

        private async Task ProcessSubmit()
        {
            var pdfData = await ModelContainer.Services.Resolve<IBusinessCardService>()
                .GeneratePDF(new GenerateParameter()
                {
                    Name = Name,
                    Organization = Organization
                });
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Path.GetTempFileName());
            File.WriteAllBytes(filePath, pdfData);
            Debug.WriteLine(filePath);
        }
    }
}
