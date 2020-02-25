using MyApp.ViewModel;
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
            ModelContainer.Services.AddNewExtension<ServicesContainerExtension>();

            base.OnStartup(e);
        }
    }
}
