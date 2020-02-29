using ReactiveUI;

namespace MyApp.ViewModel
{
    public class MainViewModel: RoutableViewModel
    {
        public MainViewModel()
        {
            Router.NavigateAndReset.Execute(new HomeViewModel(this));
        }
    }
}
