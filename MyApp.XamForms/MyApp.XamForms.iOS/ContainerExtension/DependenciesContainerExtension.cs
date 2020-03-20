using MyApp.Dependencies;
using MyApp.XamForms.Dependencies;
using Unity;
using Unity.Extension;

namespace MyApp.XamForms.iOS.ContainerExtension
{
    public class DependenciesContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IMessageDialog, MessageDialog>();
        }
    }
}
