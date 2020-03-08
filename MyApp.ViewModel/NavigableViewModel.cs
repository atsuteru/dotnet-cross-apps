using ReactiveUI;

namespace MyApp.ViewModel
{
    public abstract class NavigableViewModel : ActivatableViewModel, IRoutableViewModel
    {
        string IRoutableViewModel.UrlPathSegment => GetType().Name.Replace("ViewModel", string.Empty);

        public IScreen HostScreen { get; }

        public NavigableViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;
        }
    }
}
