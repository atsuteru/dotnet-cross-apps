using MyApp.ViewModel;
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
            ModelContainer.Services.AddNewExtension<ServicesContainerExtension>();

            base.OnStartup(e);
        }
    }
}
