using MyApp.ViewModel;
using ReactiveUI;
using ReactiveUI.XamForms;
using System;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Unity;
using static MyApp.Dependencies.MessageDialog;

namespace MyApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class HomeView : ReactiveContentPage<HomeViewModel>
    {
        public HomeView()
        {
            InitializeComponent();

            this.WhenActivated((d) =>
            {
                HandleViewModelBound(d);
            });
        }

        protected void HandleViewModelBound(CompositeDisposable d)
        {
            this.Bind(ViewModel, vm => vm.Name, v => v.NameTextBox.Text).DisposeWith(d);
            this.Bind(ViewModel, vm => vm.Organization, v => v.OrganizationTextBox.Text).DisposeWith(d);
            this.BindCommand(ViewModel, vm => vm.SubmitCommand, v => v.GenerateButton).DisposeWith(d);

            MessageBus.Current.Listen<MessageDialogRequest>().Subscribe(async (x) => await HandleMessageDialogRequest(x)).DisposeWith(d);
        }

        protected async Task HandleMessageDialogRequest(MessageDialogRequest request)
        {
            await DisplayAlert(request.Title, request.Message, "OK");
        }
    }
}
