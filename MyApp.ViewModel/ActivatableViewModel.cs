using MyApp.Dependencies;
using MyApp.Services;
using ReactiveUI;
using Splat;
using System.Reactive.Disposables;
using Unity;

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
