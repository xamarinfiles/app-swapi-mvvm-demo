using System;
using FancyLogger;
using SwapiMvvm.Forms.Services;
using SwapiMvvm.Forms.Services.Messaging;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwapiMvvm.Forms
{
    public partial class App : Application
    {

        #region Constructor

        public App()
        {
            try
            {
                InitializeComponent();

                ServiceManager = new ServiceManager();

                MainPage = new MainPage();
            }
            catch (Exception exception)
            {
                MessagingService.SendErrorMessage(exception);
            }
        }

        #endregion

        #region Protected Overrides

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        #endregion

        #region Internal Services

        internal static INavigationService NavService { get; private set; }

        private static ServiceManager ServiceManager { get; set; }

        internal static FancyLoggerService LoggingService =>
            ServiceManager.LoggingService;

        internal static MessagingService MessagingService =>
            ServiceManager.MessagingService;

        #endregion

        #region Properties

        #endregion

        #region Private

        #endregion
    }
}
