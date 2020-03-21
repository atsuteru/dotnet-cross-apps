using MyApp.Dependencies;
using MyApp.Models;
using MyApp.Models.Application;
using MyApp.Services.BusinessCard;
using MyApp.WinForms.NetFramework.Dependencies;
using ReactiveUI;
using Splat;
using System;
using System.Windows.Forms;

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

            // Regist Services
            Locator.CurrentMutable.RegisterLazySingleton<IBusinessCardService>(() => new BusinessCardService());
            // Regist Dependencies
            Locator.CurrentMutable.Register<IMessageDialog>(() => new MessageDialog());
            // Regist Model
            Locator.CurrentMutable.RegisterConstant(new ModelState(x => new ApplicationStarter(x)));
            // Regist ViewModels
            Locator.CurrentMutable.RegisterViewsForViewModels(typeof(MainForm).Assembly);

            Application.Run(new MainForm());
        }
    }
}
