using MyApp.ViewModel;
using ReactiveUI;
using ReactiveUI.Winforms;
using System.Reactive.Disposables;

namespace MyApp.WinForms
{
    public partial class ResultView : ReactiveUserControl<ResultViewModel>
    {
        protected bool IsViewModelBound { get; private set; }

        public ResultView()
        {
            InitializeComponent();

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
            this.OneWayBind(ViewModel, vm => vm.Name, v => v.NameTextBox.Text).DisposeWith(d);
            this.OneWayBind(ViewModel, vm => vm.Organization, v => v.OrganizationTextBox.Text).DisposeWith(d);
            this.OneWayBind(ViewModel, vm => vm.Result, v => v.ResultTextBox.Text).DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.BackCommand, v => v.BackButton).DisposeWith(d);
        }
    }
}
