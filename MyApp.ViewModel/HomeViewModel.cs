using MyApp.Models.BusinessCard;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace MyApp.ViewModel
{
    public class HomeViewModel: RouteViewModelBase
    {
        [Reactive]
        public string Name { get; set; }

        [Reactive]
        public string Organization { get; set; }

        public ReactiveCommand<Unit, GenerateResponse> SubmitCommand { get; protected set; }

        public HomeViewModel(IModelAccessableScreen hostScreen) : base(hostScreen)
        {
        }

        protected override void HandleActivation(CompositeDisposable d)
        {
            IsCommandExecutable = false;

            SubmitCommand = ReactiveCommand
                .CreateFromObservable(() =>
                {
                    return ((BusinessCardGenerator)Screen.Model.Router.Current)
                        .Generate(new GenerateRequest()
                        {
                            Name = Name,
                            Organization = Organization
                        });
                }, CommandExecutable);

            SubmitCommand
                .Select(response =>
                {
                    return new ResultViewModel(Screen)
                    {
                        Name = Name,
                        Organization = Organization,
                        Result = response.Result
                    };
                })
                .Select(x => Screen.Router.Navigate.Execute(x).Subscribe())
                .Subscribe()
                .DisposeWith(d);

            IsCommandExecutable = true;
        }
    }
}
