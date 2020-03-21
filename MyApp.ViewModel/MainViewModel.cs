using MyApp.Models;
using MyApp.Models.Application;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace MyApp.ViewModel
{
    public class MainViewModel: ScreenHostViewModelBase
    {
        [Reactive]
        public string ApplicationTitle { get; set; }

        public MainViewModel(ModelState model): base(model)
        {
            ApplicationTitle = AppDomain.CurrentDomain.FriendlyName;

            ((ApplicationStarter)Model.Current)
                .Initialize(new InitializeRequest())
                .Select(x =>
                {
                    return new HomeViewModel(this);
                })
                .Select(Router.Navigate.Execute)
                .Subscribe();
        }

        protected override void HandleActivation(CompositeDisposable d)
        {
            this.WhenAnyObservable(_ => _.Router.NavigationChanged)
                .Subscribe(x =>
                {
                    ApplicationTitle = string.Format("{0} [{1}]", AppDomain.CurrentDomain.FriendlyName, Router.GetCurrentViewModel()?.UrlPathSegment);
                })
                .DisposeWith(d);
        }
    }
}
