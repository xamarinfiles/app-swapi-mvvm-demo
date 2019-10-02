using System;
using System.Reflection;
using System.Threading.Tasks;
using SwapiMvvm.Forms.Services.Models;

namespace SwapiMvvm.Forms.Navigation
{
    // Adapted from "Xamarin Forms – View Model First Navigation":
    // https://codemilltech.com/xamarin-forms-view-model-first-navigation/
    // https://github.com/codemillmatt/XamFormsVMNav

    public interface INavigationService
    {
        void RegisterPageModels(Assembly asm);

        uint? SharedPageDepth { get; set; }

        #region Navigation Stack Methods

        Task PopAsync();

        Task PopToRootAsync();

        Task PopToSharedAsync();

        Task PushAsync(Type pageModelType, NavigationState navState);

        Task PushFromRootAsync(Type pageModelType, NavigationState navState);

        Task PushFromSharedAsync(Type pageModelType, NavigationState navState);

        Task ReplaceAsync(Type pageModelType, NavigationState navState);

        Task ReplaceRootAsync(Type pageModelType, NavigationState navState);

        #endregion

        #region Modal Stack Methods

        Task PopModalAsync();

        Task PushModalAsync(Type pageModelType);

        #endregion
    }
}