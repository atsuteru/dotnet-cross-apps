using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace MyApp.ViewModel
{
    public class MainViewModel: RoutableViewModel, IActivatableViewModel
    {
        [Reactive]
        public string ApplicationTitle { get; set; }

        public ViewModelActivator Activator { get; }

        public MainViewModel()
        {
            ApplicationTitle = AppDomain.CurrentDomain.FriendlyName;

            Activator = new ViewModelActivator();
            this.WhenActivated(d =>
            {
                HandleViewModelActivated(d);
            });

            Router.NavigateAndReset.Execute(new HomeViewModel(this)).Subscribe();
        }

        protected void HandleViewModelActivated(CompositeDisposable d)
        {
            this.WhenAnyObservable(x => x.Router.NavigationChanged)
                .Subscribe(x =>
                {
                    ApplicationTitle = string.Format("{0} [{1}]", AppDomain.CurrentDomain.FriendlyName, Router.GetCurrentViewModel().UrlPathSegment);
                })
                .DisposeWith(d);
        }
    }
}
