using MyApp.Dependencies;
using MyApp.Services;
using MyApp.WPF.NetFramework.ContainerExtension;
using ReactiveUI;
using Splat;
using System.Windows;
using Unity;

namespace MyApp.WPF.NetFramework
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Locator.CurrentMutable.RegisterConstant((ServiceContainer)new ServiceContainer().AddNewExtension<ServicesContainerExtension>());
            Locator.CurrentMutable.RegisterConstant((DependencyContainer)new DependencyContainer().AddNewExtension<DependenciesContainerExtension>());
            Locator.CurrentMutable.RegisterViewsForViewModels(typeof(MainWindow).Assembly);

            base.OnStartup(e);
        }
    }
}
