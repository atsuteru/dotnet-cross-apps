using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive.Linq;

namespace MyApp.ViewModel
{
    public abstract class RouteViewModelBase : RoutableViewModel
    {
        public IModelAccessableScreen Screen { get; }

        protected IObservable<bool> CommandExecutable { get; }

        [Reactive]
        public bool IsCommandExecutable { get; protected set; }

        public RouteViewModelBase(IModelAccessableScreen hostScreen) : base(hostScreen)
        {
            Screen = hostScreen;

            CommandExecutable = this.ObservableForProperty(x => x.IsCommandExecutable)
                .Select(x => x.Value);
        }
    }
}
