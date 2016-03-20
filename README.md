# Dynamic Modules
Dynamic Modules is a sample for a dynamic modular application based on the PRISM-Library and the Modern UI for WPF (MUI) toolkit for creating metro-styled, modern UI WPF applications in a plugin architecture.

A few time ago a colleague of mine told me about a problem he had to solve. A customer asked him to develop a desktop application that present a different set of features in accordance to which of the enterprise offices is running the software. On the one hand, I remembered how to do that from a past project where I was involved. On the other hand, there is an open source project for creating WPF applications with a modern look & feel, which I am following since a couple of years because I think it's really great.

I wondered if there is a way to solve the problem by using the open source MUI library for creating a plugin architecture, and came out with a prototype solution which I am presenting here.

<p>The central ideas for creating the plugin architecture are</p>
<ul>
	<li>Dynamically load the desired project modules.</li>
	<li>Dynamically build the main menu from the loaded modules.</li>
	<li>Each loaded module will expose an entry point for an option in the main menu.</li>
	<li>The first option in the main menu will be fixed and common for every user.</li>
</ul>
