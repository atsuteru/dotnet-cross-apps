using MyApp.Models;
using MyApp.Models.Application;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;

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

            InitializeResponse initializeResult;
            using(var d = new CompositeDisposable())
            {
                var completionSource = new TaskCompletionSource<InitializeResponse>();
                Model.Bus.Listen<InitializeResponse>()
                    .Subscribe(x =>
                    {
                        completionSource.SetResult(x);
                    })
                    .DisposeWith(d);
                Model.Bus.SendMessage(new InitializeRequest());
                initializeResult = completionSource.Task.Result;
            }
            Router.NavigateAndReset.Execute(new HomeViewModel(this)).Subscribe();
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
