using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FancyLogger;
using SwapiMvvm.Forms.PageModels;
using SwapiMvvm.Forms.Services.Messaging;
using SwapiMvvm.Forms.Services.Models;
using Xamarin.Forms;
using static SwapiMvvm.Forms.Services.Models.NavigationState.AppSection;

namespace SwapiMvvm.Forms.Navigation
{
    // Adapted from "Xamarin Forms – View Model First Navigation":
    // https://codemilltech.com/xamarin-forms-view-model-first-navigation/
    // https://github.com/codemillmatt/XamFormsVMNav

    // NOTE Animation has been removed since built-in animation for each OS isn't useful
    public class NavigationService : INavigationService
    {
        #region Enums

        #endregion

        #region Constructors

        public NavigationService(Assembly assembly)
        {
            RegisterPageModels(assembly);
        }

        #endregion

        #region Service Mappings

        private static FancyLoggerService LoggingService => App.LoggingService;

        private static MessagingService MessagingService => App.MessagingService;

        #endregion

        #region Interface

        // TODO Add static dictionary in release build to avoid using System.Reflection
        public void RegisterPageModels(Assembly asm)
        {
            // Loop through everything in the assembly that implements IPageFor<T>
            foreach (var pageType in asm.DefinedTypes
                .Where(dt => !dt.IsAbstract &&
                             dt.ImplementedInterfaces.Any(ii => ii == typeof(IPageFor))))
            {
                // Get the IPageFor<T> portion of the type that implements it
                var pageModelType =
                    pageType.ImplementedInterfaces.First(
                        ii => ii.IsConstructedGenericType &&
                              ii.GetGenericTypeDefinition() == typeof(IPageFor<>));

                var pageModelKey = pageModelType.GenericTypeArguments[0];
                var pageValue = pageType.AsType();

                // Same PageModel used for multiple Pages
                if (_pageModelPageDictionary.ContainsKey(pageModelKey))
                {
                    LoggingService.WriteWarning(
                        $"Skipping second {pageValue} declared for {pageModelKey}");

                    continue;
                }

                // Save it with the PageModelType as the key and the PageType as the value
                SavePageForPageModel(pageModelKey, pageValue);
            }

            LoggingService.WriteDictionary(_pageModelPageDictionary, "PageModels -> Pages");
        }

        // Useful for keeping a shared page on the navigation stack (like a home page)
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
        public uint? SharedPageDepth { get; set; }

        #region Navigation Methods

        public async Task PopAsync()
        {
            await FormsNavigation.PopAsync(false);

            PrintNavigationStackDepth("PopAsync");
        }

        public async Task PopToRootAsync()
        {
            switch (Device.RuntimePlatform)
            {
                // TODO Test if still need
                case Device.UWP:
                    // Fix for Windows and Windows Phone
                    while (NavigationStackDepth > 1)
                        await FormsNavigation.PopAsync(false);

                    break;
                default:
                    await FormsNavigation.PopToRootAsync(false);

                    break;
            }

            PrintNavigationStackDepth("PopToRootAsync");
        }

        public async Task PopToSharedAsync()
        {
            if (SharedPageDepth == 0)
                throw new InvalidOperationException(
                    "SharedPageDepth must be greater than 0 if specified");

            while (NavigationStackDepth > (SharedPageDepth ?? 1))
                await FormsNavigation.PopAsync(false);

            PrintNavigationStackDepth("PopToSharedAsync");
        }

        public async Task PushAsync(Type pageModelType, NavigationState navState)
        {
            var page = InstantiatePage(pageModelType, navState);

            await FormsNavigation.PushAsync((Page) page, false);

            PrintNavigationStackDepth("PushAsync");
        }

        public async Task PushFromRootAsync(Type pageModelType, NavigationState navState)
        {
            await PopToRootAsync();
            await PushAsync(pageModelType, navState);

            PrintNavigationStackDepth("PushFromRootAsync");
        }

        public async Task PushFromSharedAsync(Type pageModelType,
            NavigationState navState)
        {
            await PopToSharedAsync();
            await PushAsync(pageModelType, navState);

            PrintNavigationStackDepth("PushFromSharedAsync");
        }

        public async Task ReplaceAsync(Type pageModelType, NavigationState navState)
        {
            var oldTopPage = TopPage;

            await PushAsync(pageModelType, navState);
            FormsNavigation.RemovePage(oldTopPage);

            PrintNavigationStackDepth("ReplaceAsync");
        }

        public async Task ReplaceRootAsync(Type pageModelType,
            NavigationState navState = null)
        {
            var pageList = FormsNavigation.NavigationStack.ToList();

            await PushAsync(pageModelType, navState);
            // Clean up old pages
            foreach (var page in pageList) FormsNavigation.RemovePage(page);

            PrintNavigationStackDepth("ReplaceRootAsync");
        }

        #endregion

        #region Modal Stack Methods

        public async Task PopModalAsync()
        {
            await FormsNavigation.PopModalAsync(false);

            PrintModalStackDepth("PopModalAsync");
        }

        public async Task PushModalAsync(Type pageModelType)
        {
            var page = InstantiatePage(pageModelType,
                new NavigationState(Modal));

            await FormsNavigation.PushModalAsync((Page) page, false);

            PrintModalStackDepth("PushModalAsync");
        }

        #endregion

        #endregion

        #region Protected

        #endregion

        #region Internal

        #endregion

        #region Private

        #region Fields

        // PageModel => Page lookup (requires PageModel and Page to be 1:1)
        private readonly Dictionary<Type, Type> _pageModelPageDictionary =
            new Dictionary<Type, Type>();

        #endregion

        #region Properties

        // Not using tabs => Simplified from the original
        private INavigation FormsNavigation =>
            Application.Current.MainPage.Navigation;

        private IReadOnlyList<Page> NavigationStack => FormsNavigation.NavigationStack;

        private int NavigationStackDepth => NavigationStack.Count;

        private Page TopPage
        {
            get
            {
                var topPageIndex = NavigationStackDepth - 1;
                var topPage = NavigationStack[topPageIndex];

                return topPage;
            }
        }

        #endregion

        #region Methods

        private IPageFor InstantiatePage(Type pageModelType,
            NavigationState navState)
        {
            // TODO Sent to error page if fails
            IPageFor pageFor = null;

            try
            {
                // Look up the Page for the corresponding PageModel
                var pageType = _pageModelPageDictionary[pageModelType];

                // Instantiate the PageModel
                var pageModel =
                    (BasePageModel) Activator.CreateInstance(pageModelType, navState);

                // Instantiate the Page and set its context to the PageModel
                var page = (Page) Activator.CreateInstance(pageType);
                page.BindingContext = pageModel;

                pageFor = (IPageFor) page;
                pageFor.PageModel = pageModel;
            }
            catch (Exception exception)
            {
                App.MessagingService.SendErrorMessage(exception);
            }

            return pageFor;
        }

        private void PrintModalStackDepth(string stackChange)
        {
            var stackList = FormsNavigation.ModalStack.ToList();

            LoggingService.WriteList(stackList, $"Modal Stack after {stackChange}");
        }

        private void PrintNavigationStackDepth(string stackChange)
        {
            var stackList = FormsNavigation.NavigationStack.ToList();

            LoggingService.WriteList(stackList, $"Navigation Stack after {stackChange}");
        }

        private void SavePageForPageModel(Type pageModelType, Type pageType)
        {
            _pageModelPageDictionary.Add(pageModelType, pageType);
        }

        #endregion

        #endregion

        #region Nested Types

        #endregion
    }
}