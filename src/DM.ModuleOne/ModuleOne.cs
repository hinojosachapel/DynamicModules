using Microsoft.Practices.Unity;
using Prism.Modularity;

namespace DM.ModuleOne
{
    public class ModuleOne : IModule
    {
        public IUnityContainer Container { get; private set; }
        
        public ModuleOne(IUnityContainer container)
        {
            Container = container;
        }

        public void Initialize()
        {
            //Container.RegisterType<InterfaceName, ClassName>();
            System.Windows.MessageBox.Show("ModuleOne has been initialized ;-)");
        }
    }
}
