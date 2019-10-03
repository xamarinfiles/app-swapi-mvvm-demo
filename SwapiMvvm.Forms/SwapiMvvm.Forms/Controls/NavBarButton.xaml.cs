using System;
using SwapiMvvm.Forms.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwapiMvvm.Forms.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavBarButton : ContentView
    {
        #region Enums

        #endregion

        #region Constructors

        public NavBarButton()
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

        #region Protected Overrides

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            try
            {
                var navItem = (FooterNavItem) BindingContext;

                if (!navItem.IsSelected)
                    return;

                NavItemName.FontAttributes = FontAttributes.Bold;
                // TODO Replace this
                Application.Current.Resources.TryGetValue("SelectedNavButtonBackground",
                    out var backgroundColor);
                if (backgroundColor != null)
                    This.BackgroundColor = (Color) backgroundColor;
            }
            catch (Exception exception)
            {
                App.MessagingService.SendErrorMessage(exception);
            }
        }

        #endregion

        #region Bindable Properties

        #endregion

        #region Properties

        #endregion

        #region Events

        #endregion

        #region Delegates

        #endregion

        #region Private

        #endregion
    }
}