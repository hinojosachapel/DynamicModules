# Dynamic Modules
Dynamic Modules is a sample prototype for a dynamic modular application based on the [PRISM-Library](https://github.com/PrismLibrary/Prism) and the [Modern UI for WPF (MUI)](https://github.com/firstfloorsoftware/mui) toolkit for creating metro-styled, modern UI WPF applications in a plugin architecture.

A few time ago a colleague of mine told me about a problem he had to solve. A customer asked him to develop a desktop application that present a different set of features in accordance to which of the enterprise offices is running the software. On the one hand, I remembered how to do that from a past project where I was involved. On the other hand, [there is an open source project](https://github.com/firstfloorsoftware/mui) for creating WPF applications with a modern look & feel, which I am following since a couple of years because I think it's really great.

I wondered if there is a way to solve the problem by using Prism and the open source MUI library for creating a plugin architecture, and came out with a prototype solution which I am presenting here.

## The central ideas for creating the plugin architecture are:
  * Dynamically load the desired project modules.
  * Dynamically build the main menu from the loaded modules.
  * Each loaded module will expose an entry point for an option in the main menu.
  * The first option in the main menu will be fixed and common for every user.

### Contributors
  * [hinojosachapel](https://github.com/hinojosachapel)
