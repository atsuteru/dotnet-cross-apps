using MyApp.ViewModel;
using System;
using System.Windows.Forms;
using Unity;

namespace MyApp.WinForms.NetFramework
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ModelContainer.Services.AddNewExtension<ServicesContainerExtension>();

            Application.Run(new MainForm(new MainViewModel()));
        }
    }
}
