using System;
using Microsoft.Practices.Unity;
using Prism.Modularity;

namespace DM.ModuleOne
{
    public class ModuleOne : IModule
    {
        private readonly IUnityContainer _container;
        
        public ModuleOne(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("ModuleOne container");
            }

            _container = container;
        }

        public void Initialize()
        {
            //_container.RegisterType<InterfaceName, ClassName>();
            System.Windows.MessageBox.Show("ModuleOne has been initialized ;-)");
        }
    }
}