using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace MyApp.ViewModel
{
    public class ModelContainer
    {
        public static IUnityContainer Services { get; }
        static ModelContainer()
        {
            Services = new UnityContainer();
        }
    }
}
