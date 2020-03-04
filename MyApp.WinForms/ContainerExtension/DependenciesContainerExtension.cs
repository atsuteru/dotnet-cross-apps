using MyApp.Dependencies;
using MyApp.WinForms.Dependencies;
using Unity;
using Unity.Extension;

namespace MyApp.WinForms.ContainerExtension
{
    public class DependenciesContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IMessageDialog, MessageDialog>();
        }
    }
}
