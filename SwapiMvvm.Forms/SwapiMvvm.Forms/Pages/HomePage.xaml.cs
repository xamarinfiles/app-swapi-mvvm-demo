using System;
using SwapiMvvm.Forms.PageModels;
using SwapiMvvm.Forms.Services.Messaging;

namespace SwapiMvvm.Forms.Pages
{
    public partial class HomePage : BasePage<HomePageModel>
    {
        #region Constructors

        public HomePage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception exception)
            {
                App.MessagingService.SendErrorMessage(exception);
            }
        }

        #endregion

        #region Interface

        #endregion

        #region Protected Overrides

        #endregion

        #region Bindable Properties

        #endregion

        #region Events

        #endregion

        #region Private

        #endregion
    }
}