using MyApp.Models.Application;
using System;

namespace MyApp.Models
{
    public class ModelHost: IModelHost
    {
        public ModelRoutingState Router { get; }

        public ModelHost(Func<IModelHost, IRoutableModel> starterFactory)
        {
            Router = new ModelRoutingState();
            Router.Navigate(starterFactory.Invoke(this));
        }
    }
}
