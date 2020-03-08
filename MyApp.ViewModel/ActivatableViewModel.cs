using ReactiveUI;
using System.Reactive.Disposables;

namespace MyApp.ViewModel
{
    public abstract class ActivatableViewModel: ReactiveObject, IActivatableViewModel
    {
        public ViewModelActivator Activator { get; }

        public ActivatableViewModel()
        {
            Activator = new ViewModelActivator();

            this.WhenActivated(disposables =>
            {
                HandleActivation(disposables);
                Disposable.Create(() => HandleDeactivation()).DisposeWith(disposables);
            });
        }

        protected virtual void HandleActivation(CompositeDisposable d)
        {
        }

        protected virtual void HandleDeactivation()
        {
        }
    }
}
