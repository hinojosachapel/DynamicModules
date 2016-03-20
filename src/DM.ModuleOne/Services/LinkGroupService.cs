using System;
using FirstFloor.ModernUI.Presentation;
using DM.Core.Interfaces;
using DM.ModuleOne.Views;

namespace DM.ModuleOne.Services
{
    /// <summary>
    /// Creates a LinkGroup
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// This is the entry point for the option menu.
    /// </remarks>
    public class LinkGroupService : ILinkGroupService
    {
        public LinkGroup GetLinkGroup()
        {
            LinkGroup _linkGroup = new LinkGroup
            {
                DisplayName = "Module One"
            };

            _linkGroup.Links.Add(new Link
            {
                DisplayName = "Module One",
                Source = new Uri($"/DM.ModuleOne;component/Views/{typeof(MainView).Name}.xaml", UriKind.Relative)
            });

            return _linkGroup;
        }
    }
}
