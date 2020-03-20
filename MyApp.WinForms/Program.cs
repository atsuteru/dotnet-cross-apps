using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MyApp.Dependencies;
using MyApp.Services;
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

            Locator.CurrentMutable.RegisterConstant((ServiceContainer)new ServiceContainer().AddNewExtension<ServicesContainerExtension>());
            Locator.CurrentMutable.RegisterConstant((DependencyContainer)new DependencyContainer().AddNewExtension<DependenciesContainerExtension>());
            Locator.CurrentMutable.RegisterViewsForViewModels(typeof(MainForm).Assembly);

            Application.Run(new MainForm());
        }
    }
}
