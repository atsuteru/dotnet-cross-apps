using MyApp.Dependencies;
using MyApp.WPF.Dependencies;
using Unity;
using Unity.Extension;

namespace MyApp.WPF.ContainerExtension
{
    public class DependenciesContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IMessageDialog, MessageDialog>();
        }
    }
}
