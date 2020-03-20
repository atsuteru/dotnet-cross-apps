using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MyApp.Dependencies;
using MyApp.Services;
using MyApp.WPF.ContainerExtension;
using ReactiveUI;
using Splat;
using System.Windows;
using Unity;

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

            Locator.CurrentMutable.RegisterConstant((ServiceContainer)new ServiceContainer().AddNewExtension<ServicesContainerExtension>());
            Locator.CurrentMutable.RegisterConstant((DependencyContainer)new DependencyContainer().AddNewExtension<DependenciesContainerExtension>());
            Locator.CurrentMutable.RegisterViewsForViewModels(typeof(MainWindow).Assembly);

            base.OnStartup(e);
        }
    }
}
