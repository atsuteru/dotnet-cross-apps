using MyApp.ViewModel;
using MyApp.WinForms.NetFramework.ContainerExtension;
using ReactiveUI;
using Splat;
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

            Locator.CurrentMutable.RegisterViewsForViewModels(typeof(MainForm).Assembly);

            ModelContainer.Dependencies.AddNewExtension<DependenciesContainerExtension>();
            ModelContainer.Services.AddNewExtension<ServicesContainerExtension>();

            Application.Run(new MainForm());
        }
    }
}
