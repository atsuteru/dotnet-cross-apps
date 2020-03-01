﻿using MyApp.Model.BusinessCard;
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
    public class HomeViewModel: NavigableViewModel
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
            byte[] pdfData = null;
            try
            {
                pdfData = await Task.Run(async () => await ModelContainer.Services.Resolve<IBusinessCardService>()
                    .GeneratePDF(new GenerateParameter()
                    {
                        Name = Name,
                        Organization = Organization
                    }));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                result = ex.Message;
            }

            if (pdfData != null)
            {
                var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Path.GetTempFileName());
                File.WriteAllBytes(filePath, pdfData);
                Debug.WriteLine(filePath);
                result = filePath;
            }

            HostScreen.Router.Navigate.Execute(new ResultViewModel(HostScreen)
            {
                Name = Name,
                Organization = Organization,
                Result = result
            });
        }
    }
}