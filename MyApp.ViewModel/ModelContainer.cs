using Unity;

namespace MyApp.ViewModel
{
    public class ModelContainer
    {
        public static IUnityContainer Dependencies { get; }

        public static IUnityContainer Services { get; }

        static ModelContainer()
        {
            Dependencies = new UnityContainer();
            Services = new UnityContainer();
        }
    }
}
