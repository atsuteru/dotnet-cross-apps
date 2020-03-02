using MyApp.ViewModel;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MyApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<MainViewModel>
    {
        protected bool IsViewModelBound { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = DataContext as MainViewModel;
            RoutedViewHost.Router = ViewModel.Router;

            this.WhenActivated((d) =>
            {
                if (IsViewModelBound)
                {
                    return;
                }
                HandleViewModelBound(d);
                IsViewModelBound = true;
            });
        }

        protected void HandleViewModelBound(CompositeDisposable d)
        {
            this.Bind(ViewModel, vm => vm.ApplicationTitle, v => v.Title).DisposeWith(d);
        }
    }
}
