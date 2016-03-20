using Microsoft.Practices.Unity;
using Prism.Modularity;

namespace DM.ModuleTwo
{
    public class ModuleTwo : IModule
    {
        public IUnityContainer Container { get; private set; }
        
        public ModuleTwo(IUnityContainer container)
        {
            Container = container;
        }

        public void Initialize()
        {
            //Container.RegisterType<InterfaceName, ClassName>();
            System.Windows.MessageBox.Show("ModuleTwo has been initialized ;-)");
        }
    }
}
