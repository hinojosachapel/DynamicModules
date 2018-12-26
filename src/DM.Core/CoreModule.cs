using System;
using Prism.Ioc;
using Prism.Modularity;
using DM.Core.Services;

namespace DM.Core
{
    public class CoreModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ICustomerService, CustomerService>();
        }
    }
}