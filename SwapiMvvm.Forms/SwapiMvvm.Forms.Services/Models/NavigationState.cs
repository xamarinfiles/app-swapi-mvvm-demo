using System;
using SwapiMvvm.Forms.Services.Messaging;

namespace SwapiMvvm.Forms.Services.Models
{
    public class NavigationState
    {
        #region Enums

        public enum AppSection
        {
            Home,
            Films,
            People,
            Species,
            About
        }

        #endregion

        #region Constructors

        public NavigationState(AppSection appSection)
        {
            try
            {
                AppSectionSelected = appSection;
            }
            catch (Exception exception)
            {
                ServiceManager.MessagingService.SendErrorMessage(exception);
            }
        }

        #endregion

        #region Public

        // Primary navigation (nav bar)
        public AppSection AppSectionSelected { get; }

        #endregion
    }
}