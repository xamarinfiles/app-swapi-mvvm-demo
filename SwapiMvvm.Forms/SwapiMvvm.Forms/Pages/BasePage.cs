using System;
using System.Diagnostics.CodeAnalysis;
using SwapiMvvm.Forms.Navigation;
using SwapiMvvm.Forms.PageModels;
using SwapiMvvm.Forms.Services.Messaging;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Application = Xamarin.Forms.Application;
using NavigationPage = Xamarin.Forms.NavigationPage;

namespace SwapiMvvm.Forms.Pages
{
    public class BasePage<TViewModel> : ContentPage, IPageFor<TViewModel>
        where TViewModel : BasePageModel
    {
        #region Fields

        #endregion

        #region Constructors

        [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
        public BasePage()
        {
            try
            {
                // Use custom footer nav bar and menu page instead of default header nav bar
                NavigationPage.SetHasNavigationBar(this, false);

                // Move iOS layout under status bar
                if (Device.RuntimePlatform == Device.iOS)
                    On<iOS>().SetUseSafeArea(true);
            }
            catch (Exception exception)
            {
                App.MessagingService.SendErrorMessage(exception);
            }
        }

        #endregion

        #region Public

        #endregion

        #region Interface

        object IPageFor.PageModel
        {
            get => PageModel;
            set => PageModel = (TViewModel) value;
        }

        public TViewModel PageModel { get; set; }

        #endregion

        #region Protected Overrides

        #endregion

        #region Bindable Properties

        #endregion

        #region Events

        #endregion

        #region Protected

        #endregion

        #region Private

        #endregion
    }
}