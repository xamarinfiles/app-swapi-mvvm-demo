using System;
using System.Collections.ObjectModel;
using SwapiMvvm.Data.Resources;
using SwapiMvvm.Forms.Pages;
using SwapiMvvm.Forms.Services.Models;
using Xamarin.Forms;
using static SwapiMvvm.Forms.App;

namespace SwapiMvvm.Forms.PageModels
{
    public class PeoplePageModel : BasePageModel
    {
        #region Fields

        #endregion

        #region Constructors

        public PeoplePageModel(NavigationState navState) : base(navState)
        {
            LoadPeopleCommand.Execute(null);
        }

        #endregion

		#region Service Mappings

		#endregion

        #region Properties

        #region Data Properties

        public ObservableCollection<Person> People { get; private set;  } =
            new ObservableCollection<Person>();

        #endregion

        #region Navigation Properties

        #endregion

        #region State Properties

        public override PageType PageType => PageType.People;

        #endregion

        #endregion

        #region Commands

        #region Data Commands

        #region LoadPeopleCommand

        public Command LoadPeopleCommand =>
            new Command(async () =>
                {
                    PageIsWaiting = true;
                    LoadPeopleCommand.ChangeCanExecute();

                    try
                    {
                        var people = await SwapiService.GetPeople();

                        if (people?.Results?.Count > 0)
                        {
                            People = new ObservableCollection<Person>(people.Results);
                        }
                    }
                    catch (Exception exception)
                    {
                        MessagingService.SendErrorMessage(exception);
                    }


                    PageIsWaiting = false;
                    LoadPeopleCommand.ChangeCanExecute();
                },
                () => !PageIsWaiting);

        #endregion

        #endregion

        #region Navigation Commands

        #endregion

        #region State Commands

        #endregion

        #endregion

        #region Internal Methods

        #endregion

        #region Protected Methods

        #endregion

        #region Private Methods

        #endregion
    }
}