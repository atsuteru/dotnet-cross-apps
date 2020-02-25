﻿using MyApp.Model.BusinessCard;
using MyApp.Model.BusinessCard.Service;
using Unity;
using Unity.Extension;
using Unity.Lifetime;

namespace MyApp.WinForms.NetFramework
{
    public class ServicesContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IBusinessCardService, BusinessCardService>(new ContainerControlledLifetimeManager());
        }
    }
}
