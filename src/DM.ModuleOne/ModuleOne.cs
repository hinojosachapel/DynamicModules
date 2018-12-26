using System;
using Prism.Ioc;
using Prism.Modularity;

namespace DM.ModuleOne
{
    public class ModuleOne : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.Register<InterfaceName, ClassName>();
            System.Windows.MessageBox.Show($"{nameof(ModuleOne)} has been initialized ;-)");
        }
    }
}