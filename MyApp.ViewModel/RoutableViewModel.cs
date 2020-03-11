using ReactiveUI;

namespace MyApp.ViewModel
{
    public abstract class RoutableViewModel : ActivatableViewModel, IRoutableViewModel
    {
        string IRoutableViewModel.UrlPathSegment => GetType().Name.Replace("ViewModel", string.Empty);

        public IScreen HostScreen { get; }

        public RoutableViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;
        }
    }
}
