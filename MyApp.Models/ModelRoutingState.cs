namespace MyApp.Models
{
    public class ModelRoutingState
    {
        public IModel Current { get; protected set; }

        public void Navigate(IModel model)
        {
            Current = model;
        }
    }
}
