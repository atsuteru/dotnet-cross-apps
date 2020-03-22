namespace MyApp.Models
{
    public abstract class ModelBase : IModel
    {
        public IModelHost Host { get; }

        public ModelBase(IModelHost host)
        {
            Host = host;
        }
    }
}
