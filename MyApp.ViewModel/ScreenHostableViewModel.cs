using ReactiveUI;

namespace MyApp.ViewModel
{
    public abstract class ScreenHostableViewModel : ActivatableViewModel, IScreen
    {
        public RoutingState Router { get; }

        public ScreenHostableViewModel()
        {
            Router = new RoutingState();
        }
    }
}
