using System;
using SwapiMvvm.Forms.PageModels;

namespace SwapiMvvm.Forms.Pages
{
    public partial class PeoplePage : BasePage<PeoplePageModel>
    {
        #region Constructors

        public PeoplePage()
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