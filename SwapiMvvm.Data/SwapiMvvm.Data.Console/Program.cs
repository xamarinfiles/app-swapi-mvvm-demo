using System;
using System.Linq;
using System.Threading.Tasks;
using FancyLogger;

namespace SwapiMvvm.Data.Console
{
    public class Program
    {
        #region Fields

        #endregion

        #region Constructor

        static async Task Main(string[] args)
        {
            try
            {
                LoggingService = new FancyLoggerService();

                Api = new Swapi();

                await PrintFilms();
                await PrintPeople();
                await PrintSpecies();
            }
            catch (Exception exception)
            {
                LoggingService?.WriteException(exception);
            }
        }

        #endregion

        #region Properties

        private static Swapi Api { get; set; }

        private static FancyLoggerService LoggingService { get; set; }

        #endregion

        #region Private

        private static async Task PrintFilms()
        {
            try
            {
                var films = await Api.GetFilms();
                var filmList = films.Results.OrderBy(film => film.ReleaseDate).ToList();

                LoggingService?.WriteList(filmList, "Films");
            }
            catch (Exception exception)
            {
                LoggingService?.WriteException(exception);
            }
        }

        private static async Task PrintPeople()
        {
            try
            {
                var people = await Api.GetPeople();
                var peopleList = people.Results.OrderBy(person => person.Name).ToList();

                LoggingService?.WriteList(peopleList, "People");
            }
            catch (Exception exception)
            {
                LoggingService?.WriteException(exception);
            }
        }

        private static async Task PrintSpecies()
        {
            try
            {
                var species = await Api.GetSpecies();
                var speciesList = species.Results.OrderBy(species => species.Name).ToList();

                LoggingService?.WriteList(speciesList, "Species");
            }
            catch (Exception exception)
            {
                LoggingService?.WriteException(exception);
            }
        }

        #endregion
    }
}
