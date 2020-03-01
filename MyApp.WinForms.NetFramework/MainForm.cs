using MyApp.ViewModel;
using ReactiveUI;
using System.Windows.Forms;

namespace MyApp.WinForms.NetFramework
{
    public partial class MainForm : Form, IViewFor<MainViewModel>
    {
        public MainViewModel ViewModel { get; set; }

        object IViewFor.ViewModel { get => ViewModel; set => ViewModel = value as MainViewModel; }

        public MainForm()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            RoutedControlHost.Router = ViewModel.Router;
        }
    }
}
