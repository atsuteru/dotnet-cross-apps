using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace MyApp.ViewModel
{
    public abstract class RouteViewModelBase : RoutableViewModel
    {
        public IModelHostableScreen Screen { get; }

        protected IObservable<bool> CommandExecutable { get; }

        [Reactive]
        public bool IsCommandExecutable { get; protected set; }

        public RouteViewModelBase(IModelHostableScreen hostScreen) : base(hostScreen)
        {
            Screen = hostScreen;

            CommandExecutable = this.ObservableForProperty(x => x.IsCommandExecutable)
                .Select(x => x.Value);
        }
    }
}
