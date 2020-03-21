using MyApp.Models.BusinessCard;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Input;

namespace MyApp.ViewModel
{
    public class HomeViewModel: RouteViewModelBase
    {
        [Reactive]
        public string Name { get; set; }

        [Reactive]
        public string Organization { get; set; }

        public ICommand SubmitCommand { get; protected set; }

        public HomeViewModel(IModelHostableScreen hostScreen) : base(hostScreen)
        {
        }

        protected override void HandleActivation(CompositeDisposable d)
        {
            IsCommandExecutable = false;

            SubmitCommand = ReactiveCommand
                .Create(() =>
                {
                    IsCommandExecutable = false;
                    Screen.Model.Bus.SendMessage(new GenerateRequest()
                    {
                        Name = Name,
                        Organization = Organization
                    });
                }, CommandExecutable)
                .DisposeWith(d);

            Screen.Model.Bus.Listen<GenerateResponse>()
                .ObserveOn(Screen.Scheduler)
                .Subscribe(response =>
                {
                    Screen.Router.Navigate.Execute(new ResultViewModel(Screen)
                    {
                        Name = Name,
                        Organization = Organization,
                        Result = response.Result
                    }).Subscribe();
                })
                .DisposeWith(d);

            IsCommandExecutable = true;
        }
    }
}
