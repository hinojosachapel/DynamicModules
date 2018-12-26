using System;
using Prism.Ioc;
using Prism.Modularity;

namespace DM.ModuleTwo
{
    public class ModuleTwo : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.Register<InterfaceName, ClassName>();
            System.Windows.MessageBox.Show($"{nameof(ModuleTwo)} has been initialized ;-)");
        }
    }
}