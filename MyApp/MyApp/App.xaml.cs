using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MyApp.ViewModel;
using ReactiveUI;
using ReactiveUI.XamForms;
using Splat;
using Xamarin.Forms;
using Unity;
using Unity.Lifetime;

namespace MyApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Locator.CurrentMutable.RegisterViewsForViewModels(GetType().Assembly);

            var screen = new MainViewModel();
            Locator.CurrentMutable.RegisterConstant(screen, typeof(IScreen));
            MainPage = new RoutedViewHost() { Router = screen.Router };
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=1d0f83ff-e5b6-4d9b-adc6-27b75d34199a;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
