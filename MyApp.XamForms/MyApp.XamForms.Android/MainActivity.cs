using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using MyApp.Dependencies;
using MyApp.Services;
using MyApp.XamForms.Droid.ContainerExtension;
using Splat;
using Unity;

namespace MyApp.XamForms.Droid
{
    [Activity(Label = "MyApp.XamForms", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Locator.CurrentMutable.RegisterConstant((DependencyContainer)
                new DependencyContainer().AddNewExtension<DependenciesContainerExtension>());
            Locator.CurrentMutable.RegisterConstant((ServiceContainer)
                new ServiceContainer().AddNewExtension<ServicesContainerExtension>());

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}