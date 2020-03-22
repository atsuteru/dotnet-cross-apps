using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MyApp.Dependencies;
using MyApp.Models;
using MyApp.Models.Application;
using MyApp.Services.BusinessCard;
using MyApp.WPF.Dependencies;
using ReactiveUI;
using Splat;
using System.Windows;

namespace MyApp.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppCenter.Start("056cd67f-fb47-4a01-936f-4df5b63a0dcf",
                   typeof(Analytics), typeof(Crashes));

            // Regist Services
            Locator.CurrentMutable.RegisterLazySingleton<IBusinessCardService>(() => new BusinessCardService());
            // Regist Dependencies
            Locator.CurrentMutable.Register<IMessageDialog>(() => new MessageDialog());
            // Regist Model
            Locator.CurrentMutable.RegisterConstant<IModelHost>(new ModelHost(x => new ApplicationStarter(x)));
            // Regist ViewModels
            Locator.CurrentMutable.RegisterViewsForViewModels(typeof(MainWindow).Assembly);

            base.OnStartup(e);
        }
    }
}
