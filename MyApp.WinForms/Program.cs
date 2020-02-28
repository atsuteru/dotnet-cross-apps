using MyApp.ViewModel;
using System;
using System.Windows.Forms;
using Unity;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

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

            ModelContainer.Services.AddNewExtension<ServicesContainerExtension>();

            Application.Run(new MainForm(new MainViewModel()));
        }
    }
}
