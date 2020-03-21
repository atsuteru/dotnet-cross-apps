using MyApp.Models.Application;
using ReactiveUI;

namespace MyApp.Models
{
    public class ModelState
    {
        public IMessageBus Bus { get; }

        public ModelBase Current { get; protected set; }

        public ModelState(IMessageBus bus)
        {
            Bus = bus;

            // Set ApplicationStarter as startup domain
            Current = new ApplicationStarter(this);
        }

        public void ChangeCurrent(ModelBase newModel)
        {
            var oldModel = Current;
            Current = newModel;
            oldModel.Dispose();
        }
    }
}
