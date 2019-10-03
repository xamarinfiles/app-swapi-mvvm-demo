using System;
using SwapiMvvm.Forms.PageModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwapiMvvm.Forms.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageHeader : ContentView
    {
        #region Constructors

        public PageHeader()
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

        //#region Protected Overrides

        //protected override void OnBindingContextChanged()
        //{
        //    base.OnBindingContextChanged();

        //    BasePageModel pageModel = (BasePageModel) BindingContext;
        //}

        //#endregion

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