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

        [Reactive]
        public string Result { get; set; }

        public ICommand SubmitCommand { private set; get; }

        public MainViewModel()
        {
            SubmitCommand = ReactiveCommand.CreateFromTask(ProcessSubmit);
        }

        private async Task ProcessSubmit()
        {
            string result = null;
            await ModelContainer.Services.Resolve<IBusinessCardService>()
            .GeneratePDF(new GenerateParameter()
            {
                Name = Name,
                Organization = Organization
            })
            .ContinueWith((t) =>
            {
                if (t.IsFaulted)
                {
                    Debug.WriteLine(t.Exception.ToString());
                    result = t.Exception.Message;
                    return;
                }
                var pdfData = t.Result;
                var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Path.GetTempFileName());
                File.WriteAllBytes(filePath, pdfData);
                Debug.WriteLine(filePath);
                result = filePath;
            });

            Result = result;
        }
    }
}
