using MyApp.Models.Application;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Input;

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

        public ICommand BackCommand { get; protected set; }

        public ResultViewModel(IModelHostableScreen hostScreen) : base(hostScreen)
        {
        }

        protected override void HandleActivation(CompositeDisposable d)
        {
            BackCommand = ReactiveCommand
                .Create(() =>
                {
                    Screen.Model.Bus.SendMessage(new InitializeRequest());
                })
                .DisposeWith(d);

            Screen.Model.Bus.Listen<InitializeResponse>()
                .ObserveOn(Screen.Scheduler)
                .Subscribe(x =>
                {
                    Screen.Router.NavigateBack.Execute().Subscribe();
                })
                .DisposeWith(d);
        }
    }
}
