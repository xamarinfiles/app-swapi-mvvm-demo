using System;
using System.Threading.Tasks;
using SwapiMvvm.Data;
using SwapiMvvm.Data.Responses;
using Species = SwapiMvvm.Data.Responses.Species;

namespace SwapiMvvm.Forms.Services.Api
{
    public class SwapiService
    {
        #region Enums

        #endregion

        #region Fields

        private readonly Swapi _swapiService;

        // HACK before caching
        private Films _films;
        private People _people;
        private Species _species;

        #endregion

        #region Constructors

        public SwapiService()
        {
            try
            {
                _swapiService = new Swapi();

                ServiceManager.LoggingService?.WriteHeader("SWAPI");
            }
            catch (Exception exception)
            {
                ServiceManager.MessagingService?.SendErrorMessage(exception);
            }
        }

        #endregion

        #region Public

        public async Task<Films> GetFilms()
        {
            try
            {
                if (_films == null)
                    _films = await _swapiService.GetFilms();

                return _films;
            }
            catch (Exception exception)
            {
                ServiceManager.MessagingService?.SendErrorMessage(exception);

                return null;
            }
        }

        public async Task<People> GetPeople()
        {
            try
            {
                if (_people == null)
                    _people = await _swapiService.GetPeople();

                return _people;
            }
            catch (Exception exception)
            {
                ServiceManager.MessagingService?.SendErrorMessage(exception);

                return null;
            }
        }

        public async Task<Species> GetSpecies()
        {
            try
            {
                if (_species ==  null)
                    _species = await _swapiService.GetSpecies();

                return _species;
            }
            catch (Exception exception)
            {
                ServiceManager.MessagingService?.SendErrorMessage(exception);

                return null;
            }
        }

        #endregion

        #region Interface

        #endregion

        #region Protected

        #endregion

        #region Internal

        #endregion

        #region Private

        #endregion

        #region Nested Types

        #endregion
    }
}
