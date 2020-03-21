using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MyApp.Models;
using MyApp.ViewModel;
using ReactiveUI;
using ReactiveUI.XamForms;
using Splat;
using Xamarin.Forms;

namespace MyApp.XamForms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Regist ViewModels
            Locator.CurrentMutable.RegisterViewsForViewModels(GetType().Assembly);

            var screen = new MainViewModel(Locator.Current.GetService<ModelState>());
            Locator.CurrentMutable.RegisterConstant(screen, typeof(IScreen));
            MainPage = new RoutedViewHost() { Router = screen.Router };
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=1d0f83ff-e5b6-4d9b-adc6-27b75d34199a;" +
                  "uwp=637a08f5-60ae-462d-b4b5-723f30ab41ad;" +
                  "ios=6a5d686c-c59e-4df5-aca8-dd51b8700299",
                  typeof(Analytics), typeof(Crashes));
        }
    }
}
