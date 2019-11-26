using System;
using System.Reflection;
using FancyLogger;
using SwapiMvvm.Forms.Navigation;
using SwapiMvvm.Forms.PageModels;
using SwapiMvvm.Forms.Services;
using SwapiMvvm.Forms.Services.Api;
using SwapiMvvm.Forms.Services.Messaging;
using SwapiMvvm.Forms.Services.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwapiMvvm.Forms
{
    public partial class App : Application
    {
        #region Fields

        private static readonly Assembly Assembly = typeof(App).Assembly;

        #endregion

        #region Constructor

        public App()
        {
            try
            {
                ServiceManager = new ServiceManager();

                InitializeComponent();

                // MainPage = new MainPage();

                NavService = new NavigationService(Assembly);

                MainPage = new NavigationPage();
                // TODO Move initiation into NavService method
                NavService.PushAsync(typeof(HomePageModel),
                    new NavigationState(AppSection.Home));
            }
            catch (Exception exception)
            {
                MessagingService?.SendErrorMessage(exception);
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

        internal static SwapiService SwapiService =>
            ServiceManager.SwapiService;

        #endregion

        #region Properties

        #endregion

        #region Private

        #endregion
    }
}
