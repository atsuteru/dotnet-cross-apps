using MyApp.ViewModel;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows.Forms;

namespace MyApp.WinForms.NetFramework
{
    public partial class MainForm : Form, IViewFor<MainViewModel>
    {
        public MainViewModel ViewModel { get; set; }

        object IViewFor.ViewModel { get => ViewModel; set => ViewModel = value as MainViewModel; }

        public MainForm(MainViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel;

            this.WhenActivated((d) =>
            {
                this.Bind(ViewModel, vm => vm.Name, v => v.NameTextBox.Text).DisposeWith(d);
                this.Bind(ViewModel, vm => vm.Organization, v => v.OrganizationTextBox.Text).DisposeWith(d);
                this.BindCommand(ViewModel, vm => vm.SubmitCommand, v => v.GenerateButton).DisposeWith(d);
            });
        }
    }
}
