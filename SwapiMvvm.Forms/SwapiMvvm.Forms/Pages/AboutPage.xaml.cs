﻿using System;
using SwapiMvvm.Forms.PageModels;

namespace SwapiMvvm.Forms.Pages
{
    public partial class AboutPage : BasePage<AboutPageModel>
    {
        #region Constructors

        public AboutPage()
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