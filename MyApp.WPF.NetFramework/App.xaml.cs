using MyApp.ViewModel;
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
            Locator.CurrentMutable.RegisterViewsForViewModels(typeof(MainWindow).Assembly);

            ModelContainer.Dependencies.AddNewExtension<DependenciesContainerExtension>();
            ModelContainer.Services.AddNewExtension<ServicesContainerExtension>();

            base.OnStartup(e);
        }
    }
}
