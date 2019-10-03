using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Refit;
using SwapiMvvm.Data.Responses;

namespace SwapiMvvm.Data
{
    public class Swapi
    {

        #region Fields

        private string baseUrl = "https://swapi.co";
        private readonly ISwapi _api;

        #endregion

        #region Constructors

        public Swapi()
        {
            try
            {
                // TODO Add HTTP logger

                _api = RestService.For<ISwapi>(baseUrl);
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        #endregion

        #region Films

        public async Task<Films> GetFilms()
        {
            try
            {
                var filmsResponse = await _api.GetFilms();

                return filmsResponse;
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        #endregion

        #region People

        public async Task<People> GetPeople()
        {
            try
            {
                var peopleResponse = await _api.GetPeople();

                return peopleResponse;
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        #endregion

        #region Species

        public async Task<Species> GetSpecies()
        {
            try
            {
                var speciesResponse = await _api.GetSpecies();

                return speciesResponse;
            }
            catch (Exception exception)
            {
                SaveExceptionLocation(exception);

                throw;
            }
        }

        #endregion

        #region Private

        private void SaveExceptionLocation(Exception exception,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            exception.Data.Add("Member Name", memberName);
            exception.Data.Add("Source File Path", sourceFilePath);
            exception.Data.Add("Source Line Number", sourceLineNumber);
        }

        #endregion
    }
}
