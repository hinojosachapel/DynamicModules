using System;
using System.Windows;
using System.Reflection;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using FirstFloor.ModernUI.Presentation;
using DM.Core.Interfaces;

namespace DM.Demo
{
    class Bootstrapper : UnityBootstrapper
    {
        private const string MODULES_PATH = @".\modules";
        private LinkGroupCollection linkGroupCollection = null;

        protected override DependencyObject CreateShell()
        {
            Shell shell = Container.Resolve<Shell>();

            if (linkGroupCollection != null)
            {
                shell.AddLinkGroups(linkGroupCollection);
            }

            return shell;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            //Container.RegisterType<InterfaceName, ClassName>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = MODULES_PATH };
        }

        protected override void ConfigureModuleCatalog()
        {
            // Dynamic Modules are copied to a directory as part of a post-build step.
            // These modules are not referenced in the startup project and are discovered 
            // by examining the assemblies in a directory. The module projects have the 
            // following post-build step in order to copy themselves into that directory:
            //
            // xcopy "$(TargetDir)$(TargetFileName)" "$(TargetDir)modules\" /y
            //
            // WARNING! Do not forget to explicitly compile the solution before each running
            // so the modules are copied into the modules folder.
            var directoryCatalog = (DirectoryModuleCatalog)ModuleCatalog;
            directoryCatalog.Initialize();

            linkGroupCollection = new LinkGroupCollection();
            var typeFilter = new TypeFilter(InterfaceFilter);

            foreach (var module in directoryCatalog.Items)
            {
                var mi = (ModuleInfo)module;
                var asm = Assembly.LoadFrom(mi.Ref);

                foreach (Type t in asm.GetTypes())
                {
                    var myInterfaces = t.FindInterfaces(typeFilter, typeof(ILinkGroupService).ToString());

                    if (myInterfaces.Length > 0)
                    {
                        // We found the type that implements the ILinkGroupService interface
                        var linkGroupService = (ILinkGroupService)asm.CreateInstance(t.FullName);
                        var linkGroup = linkGroupService.GetLinkGroup();
                        linkGroupCollection.Add(linkGroup);
                    }
                }
            }

            // Module CoreModule is defined in the code.
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            moduleCatalog.AddModule(typeof(Core.CoreModule));
        }

        private bool InterfaceFilter(Type typeObj, Object criteriaObj)
        {
            return typeObj.ToString() == criteriaObj.ToString();
        }
    }
}