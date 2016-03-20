using Microsoft.Practices.Unity;
using Prism.Modularity;
using DM.Core.Services;

namespace DM.Core
{
    public class CoreModule : IModule
    {
        public IUnityContainer Container { get; private set; }
        
        public CoreModule(IUnityContainer container)
        {
            Container = container;
        }

        public void Initialize()
        {
            Container.RegisterType<ICustomerService, CustomerService>(new ContainerControlledLifetimeManager());
        }
    }
}