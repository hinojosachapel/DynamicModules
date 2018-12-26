using System;
using System.Reflection;
using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using FirstFloor.ModernUI.Presentation;
using DM.Core.Interfaces;

namespace DM.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private const string MODULES_PATH = @".\modules";
        private LinkGroupCollection linkGroupCollection = null;

        protected override Window CreateShell()
        {
            var shell = Container.Resolve<Shell>();

            if (linkGroupCollection != null)
            {
                shell.AddLinkGroups(linkGroupCollection);
            }

            return (Window)shell;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.Register<InterfaceName, ClassName>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = MODULES_PATH };
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            // Dynamic Modules are copied to a directory as part of a post-build step.
            // These modules are not referenced in the startup project and are discovered 
            // by examining the assemblies in a directory. The module projects have the 
            // following post-build step in order to copy themselves into that directory:
            //
            // xcopy "$(TargetDir)$(TargetFileName)" "$(TargetDir)modules\" /y
            //
            // WARNING! Do not forget to build the solution (F6) before each running
            // so the modules are copied into the modules folder.
            var directoryCatalog = (DirectoryModuleCatalog)moduleCatalog;
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

            moduleCatalog.AddModule(typeof(Core.CoreModule));
        }

        private bool InterfaceFilter(Type typeObj, Object criteriaObj)
        {
            return typeObj.ToString() == criteriaObj.ToString();
        }
    }
}