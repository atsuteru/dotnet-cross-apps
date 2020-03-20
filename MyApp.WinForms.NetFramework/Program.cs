using MyApp.Dependencies;
using MyApp.Services;
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

            Locator.CurrentMutable.RegisterConstant((ServiceContainer)new ServiceContainer().AddNewExtension<ServicesContainerExtension>());
            Locator.CurrentMutable.RegisterConstant((DependencyContainer)new DependencyContainer().AddNewExtension<DependenciesContainerExtension>());
            Locator.CurrentMutable.RegisterViewsForViewModels(typeof(MainForm).Assembly);

            Application.Run(new MainForm());
        }
    }
}
