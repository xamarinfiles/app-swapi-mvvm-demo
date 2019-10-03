using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using SwapiMvvm.Forms.Models;
using SwapiMvvm.Forms.Pages;
using SwapiMvvm.Forms.Services.Models;
using Xamarin.Forms;
using static SwapiMvvm.Forms.App;
using static SwapiMvvm.Forms.Services.Models.NavigationState;

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

            LoggingService.WriteHeader(PageName);

            FooterNavItems = BuildNavigationMenu();
        }

        #endregion

        #region Service Mappings

        #endregion

        #region Properties

        #region Data Properties

        #endregion

        #region Navigation Properties

        public IList<FooterNavItem> FooterNavItems { get; private set; }

        public NavigationState NavState { get; private set; }

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

        #region GoToNavBarPageCommand

        public Command<AppSection> GoToAppSectionCommand =>
            new Command<AppSection>(async appSection =>
            {
                try
                {
                    switch (appSection)
                    {
                        case AppSection.Home:
                            await ExecuteGoToPageCommand(PageType.Home,
                                new NavigationState(AppSection.Home));
                            break;
                        case AppSection.Films:
                            await ExecuteGoToPageCommand(PageType.Films,
                                new NavigationState(AppSection.Films));
                            break;
                        case AppSection.People:
                            await ExecuteGoToPageCommand(PageType.People,
                                new NavigationState(AppSection.People));
                            break;
                        case AppSection.Species:
                            await ExecuteGoToPageCommand(PageType.Species,
                                new NavigationState(AppSection.Species));
                            break;
                        case AppSection.About:
                            await ExecuteGoToPageCommand(PageType.About,
                                new NavigationState(AppSection.About));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(appSection),
                                appSection, null);
                    }
                }
                catch (Exception exception)
                {
                    MessagingService.SendErrorMessage(exception);
                }
            });

        #endregion

        #region ExecuteGoToPageCommand

        private async Task ExecuteGoToPageCommand(PageType nextPage,
            NavigationState navState)
        {
            var currentPage = PageType;

            // Already on the page => ignore the request
            if (currentPage == nextPage)
                return;

            LoggingService.WriteSubheader("Navigation initiated");
            LoggingService.WriteValue("Current Page", currentPage);
            LoggingService.WriteValue("Next Page", nextPage);

            try
            {
                switch (nextPage)
                {
                    case PageType.Home:
                        await NavService.ReplaceRootAsync(typeof(HomePageModel),
                            navState);
                        break;
                    case PageType.Films:
                        await NavService.ReplaceRootAsync(typeof(FilmsPageModel),
                            navState);
                        break;
                    case PageType.People:
                        await NavService.ReplaceRootAsync(typeof(PeoplePageModel),
                            navState);
                        break;
                    case PageType.Species:
                        await NavService.ReplaceRootAsync(typeof(SpeciesPageModel),
                            navState);
                        break;
                    case PageType.About:
                        await NavService.ReplaceRootAsync(typeof(AboutPageModel),
                            navState);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(nextPage), nextPage,
                            null);
                }
            }
            catch (Exception exception)
            {
                MessagingService.SendErrorMessage(exception);
            }
        }

        #endregion

        #endregion

        #region State Commands

        #endregion

        #endregion

        #region Private

        private IList<FooterNavItem> BuildNavigationMenu()
        {
            var footerNavItems = new List<FooterNavItem>();

            AddFooterNavItem(AppSection.Home);
            AddFooterNavItem(AppSection.Films);
            AddFooterNavItem(AppSection.People);
            AddFooterNavItem(AppSection.Species);
            AddFooterNavItem(AppSection.About);

            return footerNavItems;

            void AddFooterNavItem(AppSection appSection)
            {
                var navItem = new FooterNavItem
                {
                    AppSection = appSection,
                    IsSelected = appSection == NavState.AppSectionSelected,
                    LabelText = appSection.NavItemName(),
                    NavigationCommand = GoToAppSectionCommand
                };

                footerNavItems.Add(navItem);
            }
        }

        #endregion
    }
}