using System;
using FirstFloor.ModernUI.Presentation;
using DM.Core.Interfaces;
using DM.ModuleTwo.Views;

namespace DM.ModuleTwo.Services
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
            LinkGroup linkGroup = new LinkGroup
            {
                DisplayName = "Module Two"
            };

            linkGroup.Links.Add(new Link
            {
                DisplayName = "Module Two",
                Source = new Uri($"/DM.ModuleTwo;component/Views/{nameof(MainView)}.xaml", UriKind.Relative)
            });

            return linkGroup;
        }
    }
}
