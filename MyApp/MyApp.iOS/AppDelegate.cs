
using Foundation;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MyApp.iOS.ContainerExtension;
using MyApp.ViewModel;
using UIKit;
using Unity;

namespace MyApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            AppCenter.Start("6a5d686c-c59e-4df5-aca8-dd51b8700299",
                   typeof(Analytics), typeof(Crashes));

            ModelContainer.Dependencies.AddNewExtension<DependenciesContainerExtension>();
            ModelContainer.Services.AddNewExtension<ServicesContainerExtension>();

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
