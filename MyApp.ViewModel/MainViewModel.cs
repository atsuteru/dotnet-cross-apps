using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace MyApp.ViewModel
{
    public class MainViewModel: ScreenHostableViewModel
    {
        [Reactive]
        public string ApplicationTitle { get; set; }

        public MainViewModel()
        {
            ApplicationTitle = AppDomain.CurrentDomain.FriendlyName;
            Router.NavigateAndReset.Execute(new HomeViewModel(this)).Subscribe();
        }

        protected override void HandleActivation(CompositeDisposable d)
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
