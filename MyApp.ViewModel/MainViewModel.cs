using MyApp.Models;
using MyApp.Models.Application;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace MyApp.ViewModel
{
    public class MainViewModel: ScreenHostViewModelBase
    {
        [Reactive]
        public string ApplicationTitle { get; set; }

        public override IScheduler Scheduler { get; }

        public MainViewModel(ModelState model, IScheduler scheduler): base(model)
        {
            ApplicationTitle = AppDomain.CurrentDomain.FriendlyName;
            Scheduler = scheduler;

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
