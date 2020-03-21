using MyApp.Models.Application;
using MyApp.Models.BusinessCard;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace MyApp.ViewModel
{
    public class ResultViewModel: RouteViewModelBase
    {
        [Reactive]
        public string Name { get; set; }

        [Reactive]
        public string Organization { get; set; }

        [Reactive]
        public string Result { get; set; }

        public ReactiveCommand<Unit, InitializeResponse> BackCommand { get; protected set; }

        public ResultViewModel(IModelHostableScreen hostScreen) : base(hostScreen)
        {
        }

        protected override void HandleActivation(CompositeDisposable d)
        {
            BackCommand = ReactiveCommand
                .CreateFromObservable(() =>
                {
                    return ((BusinessCardGenerator)Screen.Model.Current)
                        .Initialize(new InitializeRequest());
                });

            BackCommand
                .Select(x => Screen.Router.NavigateBack.Execute().Subscribe())
                .Subscribe()
                .DisposeWith(d);
        }
    }
}
