using MyApp.Services.BusinessCard;
using Unity;
using Unity.Extension;
using Unity.Lifetime;

namespace MyApp.XamForms.UWP.ContainerExtension
{
    public class ServicesContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IBusinessCardService, BusinessCardService>(new ContainerControlledLifetimeManager());
        }
    }
}
