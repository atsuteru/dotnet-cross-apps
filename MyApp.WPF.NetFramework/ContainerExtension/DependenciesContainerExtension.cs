using MyApp.Dependencies;
using MyApp.WPF.NetFramework.Dependencies;
using Unity;
using Unity.Extension;

namespace MyApp.WPF.NetFramework.ContainerExtension
{
    public class DependenciesContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IMessageDialog, MessageDialog>();
        }
    }
}
