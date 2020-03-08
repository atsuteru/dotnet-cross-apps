using ReactiveUI;

namespace MyApp.ViewModel
{
    public abstract class RoutableViewModel : ActivatableViewModel, IScreen
    {
        public RoutingState Router { get; }

        public RoutableViewModel()
        {
            Router = new RoutingState();
        }
    }
}
