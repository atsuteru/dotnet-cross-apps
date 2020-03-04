using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MyApp.ViewModel;
using MyApp.WinForms.ContainerExtension;
using ReactiveUI;
using Splat;
using System;
using System.Windows.Forms;
using Unity;

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

            Locator.CurrentMutable.RegisterViewsForViewModels(typeof(MainForm).Assembly);

            ModelContainer.Dependencies.AddNewExtension<DependenciesContainerExtension>();
            ModelContainer.Services.AddNewExtension<ServicesContainerExtension>();

            Application.Run(new MainForm());
        }
    }
}
