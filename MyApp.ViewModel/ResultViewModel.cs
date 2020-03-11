using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;

namespace MyApp.ViewModel
{
    public class ResultViewModel: RoutableViewModel
    {
        [Reactive]
        public string Name { get; set; }

        [Reactive]
        public string Organization { get; set; }

        [Reactive]
        public string Result { get; set; }

        public ICommand BackCommand { get; }

        public ResultViewModel(IScreen hostScreen) : base(hostScreen)
        {
            BackCommand = HostScreen.Router.NavigateBack;
        }
    }
}
