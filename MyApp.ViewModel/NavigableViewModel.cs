using ReactiveUI;
using System.Reactive.Disposables;

namespace MyApp.ViewModel
{
    public abstract class NavigableViewModel : ReactiveObject, IRoutableViewModel, IActivatableViewModel
    {
        string IRoutableViewModel.UrlPathSegment => GetType().Name.Replace("ViewModel", string.Empty);

        public IScreen HostScreen { get; }

        public ViewModelActivator Activator { get; }

        public NavigableViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;
            Activator = new ViewModelActivator();

            this.WhenActivated(disposables =>
            {
                HandleActivation();
                Disposable.Create(() => HandleDeactivation()).DisposeWith(disposables);
            });
        }

        protected virtual void HandleActivation()
        {
        }

        protected virtual void HandleDeactivation()
        {
        }
    }
}
