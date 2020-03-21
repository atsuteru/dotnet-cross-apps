using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MyApp.Dependencies;
using MyApp.Services.BusinessCard;
using MyApp.WinForms.Dependencies;
using ReactiveUI;
using Splat;
using System;
using System.Windows.Forms;

namespace MyApp.WinForms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppCenter.Start("a7a83300-7c5a-4dfa-8d3b-c29d6aed7f1b",
                   typeof(Analytics), typeof(Crashes));

            // Regist Services
            Locator.CurrentMutable.RegisterLazySingleton<IBusinessCardService>(() => new BusinessCardService());
            // Regist Dependencies
            Locator.CurrentMutable.Register<IMessageDialog>(() => new MessageDialog());
            // Regist ViewModels
            Locator.CurrentMutable.RegisterViewsForViewModels(typeof(MainForm).Assembly);

            Application.Run(new MainForm());
        }
    }
}
