using MyApp.ViewModel;
using ReactiveUI;

namespace MyApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<MainViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = DataContext as MainViewModel;
            RoutedViewHost.Router = ViewModel.Router;
        }
    }
}
