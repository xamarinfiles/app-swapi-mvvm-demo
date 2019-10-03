using System;
using SwapiMvvm.Forms.Services.Models;
using static SwapiMvvm.Forms.Resources.Strings;

namespace SwapiMvvm.Forms.Pages
{
    public static class PageTypeHelper
    {
        public static string PageTitle(this PageType pageType, NavigationState navState)
        {
            var pageTitle = "";

            try
            {
                // Override page title from PageType to make user-friendly or appropriate
                switch (pageType)
                {
                    case PageType.Home:
                        pageTitle = HomePageTitle;

                        break;
                    default:
                        // Use PageType for default page title and navigation testing
                        pageTitle = pageType.ToString();
                        break;
                }
            }
            catch (Exception exception)
            {
                App.MessagingService.SendErrorMessage(exception);
            }

            return pageTitle;
        }
    }
}
