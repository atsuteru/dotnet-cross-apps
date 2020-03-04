using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MyApp.ViewModel;
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

            Locator.CurrentMutable.RegisterViewsForViewModels(typeof(MainWindow).Assembly);

            ModelContainer.Dependencies.AddNewExtension<DependenciesContainerExtension>();
            ModelContainer.Services.AddNewExtension<ServicesContainerExtension>();

            base.OnStartup(e);
        }
    }
}
