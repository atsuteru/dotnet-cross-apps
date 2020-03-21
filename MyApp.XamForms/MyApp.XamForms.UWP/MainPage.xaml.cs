namespace MyApp.XamForms.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new MyApp.XamForms.App());
        }
    }
}
