namespace MyApp.Models
{
    public abstract class RouteModelBase : IRoutableModel
    {
        public IModelHost Host { get; }

        public RouteModelBase(IModelHost host)
        {
            Host = host;
        }
    }
}
