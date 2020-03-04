using MyApp.Dependencies;
using MyApp.WinForms.NetFramework.Dependencies;
using Unity;
using Unity.Extension;

namespace MyApp.WinForms.NetFramework.ContainerExtension
{
    public class DependenciesContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IMessageDialog, MessageDialog>();
        }
    }
}
