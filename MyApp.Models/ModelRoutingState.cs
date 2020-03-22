namespace MyApp.Models
{
    public class ModelRoutingState
    {
        public IRoutableModel Current { get; protected set; }

        public void Navigate(IRoutableModel model)
        {
            Current = model;
        }
    }
}
