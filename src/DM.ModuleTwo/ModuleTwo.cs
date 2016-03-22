using System;
using Microsoft.Practices.Unity;
using Prism.Modularity;

namespace DM.ModuleTwo
{
    public class ModuleTwo : IModule
    {
        private readonly IUnityContainer _container;

        public ModuleTwo(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("ModuleTwo container");
            }

            _container = container;
        }

        public void Initialize()
        {
            //_container.RegisterType<InterfaceName, ClassName>();
            System.Windows.MessageBox.Show("ModuleTwo has been initialized ;-)");
        }
    }
}