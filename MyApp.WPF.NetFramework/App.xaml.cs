using MyApp.Dependencies;
using MyApp.Models;
using MyApp.Models.Application;
using MyApp.Services.BusinessCard;
using MyApp.WPF.NetFramework.Dependencies;
using ReactiveUI;
using Splat;
using System.Windows;

namespace MyApp.WPF.NetFramework
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Regist Services
            Locator.CurrentMutable.RegisterLazySingleton<IBusinessCardService>(() => new BusinessCardService());
            // Regist Dependencies
            Locator.CurrentMutable.Register<IMessageDialog>(() => new MessageDialog());
            // Regist Model
            Locator.CurrentMutable.RegisterConstant(new ModelState(x => new ApplicationStarter(x)));
            // Regist ViewModels
            Locator.CurrentMutable.RegisterViewsForViewModels(typeof(MainWindow).Assembly);

            base.OnStartup(e);
        }
    }
}
