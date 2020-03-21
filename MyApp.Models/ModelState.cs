using MyApp.Models.Application;
using System;

namespace MyApp.Models
{
    public class ModelState
    {
        public ModelBase Current { get; protected set; }

        public ModelState(Func<ModelState, ApplicationStarter> starterFactory)
        {
            // Set ApplicationStarter as startup domain
            Current = starterFactory.Invoke(this);
        }

        public void ChangeCurrent(ModelBase newModel)
        {
            var oldModel = Current;
            Current = newModel;
            oldModel.Dispose();
        }
    }
}
