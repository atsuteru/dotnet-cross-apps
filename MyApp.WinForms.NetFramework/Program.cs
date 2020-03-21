using MyApp.Dependencies;
using MyApp.Models;
using MyApp.Services.BusinessCard;
using MyApp.WinForms.NetFramework.Dependencies;
using ReactiveUI;
using Splat;
using System;
using System.Reactive.Concurrency;
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
            var messageBus = new MessageBus();
            Locator.CurrentMutable.RegisterConstant(new ModelState(messageBus));
            // Regist ViewModels
            Locator.CurrentMutable.RegisterViewsForViewModels(typeof(MainForm).Assembly);

            Application.Run(new MainForm());
        }
    }
}
