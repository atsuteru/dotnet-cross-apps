using MyApp.Models;
using MyApp.ViewModel;
using ReactiveUI;
using Splat;
using System.Reactive.Disposables;
using System.Windows.Forms;

namespace MyApp.WinForms.NetFramework
{
    public partial class MainForm : Form, IViewFor<MainViewModel>
    {
        protected bool IsViewModelBound { get; private set; }

        public MainViewModel ViewModel { get; set; }

        object IViewFor.ViewModel { get => ViewModel; set => ViewModel = value as MainViewModel; }

        public MainForm()
        {
            InitializeComponent();

            ViewModel = new MainViewModel(Locator.Current.GetService<ModelState>());
            RoutedControlHost.Router = ViewModel.Router;

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
            this.Bind(ViewModel, vm => vm.ApplicationTitle, v => v.Text).DisposeWith(d);
        }
    }
}
