using MyApp.ViewModel;
using ReactiveUI;

namespace MyApp.WPF.NetFramework
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
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
