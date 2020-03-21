using ReactiveUI;

namespace MyApp.ViewModel
{
    public abstract class RoutableViewModel : ActivatableViewModel, IRoutableViewModel
    {
        string IRoutableViewModel.UrlPathSegment => GetUrlPathSegment();

        private IScreen _hostScreen;

        IScreen IRoutableViewModel.HostScreen { get => _hostScreen; }

        public RoutableViewModel(IScreen hostScreen)
        {
            _hostScreen = hostScreen;
        }

        protected virtual string GetUrlPathSegment()
        {
            return GetType().Name.Replace("ViewModel", string.Empty);
        }
    }
}
