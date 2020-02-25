using MyApp.ViewModel;
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

            ModelContainer.Services.AddNewExtension<ServicesContainerExtension>();

            Application.Run(new MainForm(new MainViewModel()));
        }
    }
}
