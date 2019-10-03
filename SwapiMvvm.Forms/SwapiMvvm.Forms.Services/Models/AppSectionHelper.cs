using System;
using System.Collections.Generic;
using System.Text;

namespace SwapiMvvm.Forms.Services.Models
{
    public static class AppSectionHelper
    {
        public static string NavItemName(this AppSection appSection)
        {
            var pageName = "";

            try
            {
                // Override page name from AppSection to make user-friendly or appropriate
                switch (appSection)
                {
                    default:
                        pageName = appSection.ToString();
                        break;
                }
            }
            catch (Exception exception)
            {
                ServiceManager.LoggingService?.WriteException(exception);
            }

            return pageName;
        }
    }
}
