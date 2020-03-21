using ReactiveUI;
using System.Reactive.Disposables;

namespace MyApp.ViewModel
{
    public abstract class ActivatableViewModel: ReactiveObject, IActivatableViewModel
    {
        public ViewModelActivator Activator { get; }

        protected bool IsViewModelBound { get; private set; }

        public ActivatableViewModel()
        {
            Activator = new ViewModelActivator();

            this.WhenActivated(disposables =>
            {
                if (IsViewModelBound)
                {
                    return;
                }
                HandleActivation(disposables);
                Disposable.Create(() => HandleDeactivation()).DisposeWith(disposables);
                IsViewModelBound = true;
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
