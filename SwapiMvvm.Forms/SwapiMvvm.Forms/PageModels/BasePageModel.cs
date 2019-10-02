using System.Diagnostics.CodeAnalysis;
using FancyLogger;
using SwapiMvvm.Forms.Pages;
using SwapiMvvm.Forms.Services.Messaging;
using SwapiMvvm.Forms.Services.Models;

namespace SwapiMvvm.Forms.PageModels
{
    public abstract class BasePageModel
    {
        #region Fields

        #endregion

        #region Constructors

        protected BasePageModel(NavigationState navState)
        {
            NavState = navState;

            App.LoggingService.WriteHeader(PageName);
        }

        #endregion

        #region Service Mappings

        #endregion

        #region Properties

        #region Data Properties

        #endregion

        #region Navigation Properties

        public NavigationState NavState { get; }

        #endregion

        #region State Properties

        public bool PageIsWaiting { get; set; }

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public string PageName => PageType.ToString();

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public string PageTitle => PageType.PageTitle(NavState);

        public abstract PageType PageType { get; }

        #endregion

        #endregion

        #region Commands

        #region Data Commands

        #endregion

        #region Navigation Commands

        #endregion

        #region State Commands

        #endregion

        #endregion

        #region Private

        #endregion
    }
}