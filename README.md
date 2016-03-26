# Dynamic Modules
Dynamic Modules is a sample prototype for a WPF modular application based on the [Prism Library](https://github.com/PrismLibrary/Prism) and the [Modern UI for WPF (MUI)](https://github.com/firstfloorsoftware/mui) Toolkit. It is a proof of concept for creating metro-styled, modern UI WPF applications in a plugin architecture.

![](https://github.com/hinojosachapel/DynamicModules/blob/master/dynamicmodules.png)

A little while ago, a colleague of mine told me about a problem he had to solve. A customer asked him to develop a desktop application that presents a different set of features in accordance to which of the enterprise offices is running the software. On the one hand, I remembered how to do that from a past project where I was involved. On the other hand, [there is an open source project](https://github.com/firstfloorsoftware/mui) for creating WPF applications with a modern look & feel, which I am following since a couple of years because I think it's really great.

I wondered if there is a way to solve the problem by using Prism and the open source MUI library for creating a plugin architecture, and came up with a prototype solution which I am presenting here.

## The central ideas for the proposed plugin architecture are:

  * Put into a directory the desired project modules (or put them all and run a filter on loading time).
  * Dynamically load the project modules from the modules folder.
  * Each module exposes an entry point for an option in the main menu.
  * Dynamically build the main menu from the loaded modules.
  * The first option in the main menu is fixed and common for every user.
  * A core module with shared services, repositories, DTOs, data model definitions, etc., is statically loaded. It can be referenced by any solution project.

Dynamic Modules are copied to a directory as part of a post-build step. These modules are not referenced in the startup project and are discovered by examining the assemblies in a directory. The module projects have the following post-build step in order to copy themselves into that directory:

xcopy "$(TargetDir)$(TargetFileName)" "$(TargetDir)<strong>modules</strong>\" /y

Note that the solution is built into "..\bin\" folder.

<strong>WARNING! Do not forget to explicitly compile the solution before each running so the modules are copied into the modules folder.</strong>

### Links of interest
You may find complementary information at:
  * [Dynamic Modules with Prism and the Modern UI for WPF Toolkit](http://www.codeproject.com/Articles/1087362/Dynamic-Modules-with-Prism-and-the-Modern-UI-for-WPF-toolkit)
  * [Modern UI for WPF (MUI) Demo project](https://github.com/firstfloorsoftware/mui/tree/master/1.0/FirstFloor.ModernUI/FirstFloor.ModernUI.App)
  * [Modern UI for WPF Templates (Visual Studio Extension)](https://visualstudiogallery.msdn.microsoft.com/7a4362a7-fe5d-4f9d-bc7b-0c0dc272fe31)
  * [Prism Samples WPF / Modularity With Unity](https://github.com/PrismLibrary/Prism-Samples-Wpf/tree/master/Modularity/ModularityWithUnity)
  * [On Prism's ViewModelLocator convention*](http://brianlagunas.com/getting-started-prisms-new-viewmodellocator/)

*Currently there is no need to "implement" the IView interface in the view's code-behind.

### Contributors
  * [hinojosachapel](https://github.com/hinojosachapel)