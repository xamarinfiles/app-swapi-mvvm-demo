using System.Threading.Tasks;
using Refit;
using SwapiMvvm.Data.Responses;

namespace SwapiMvvm.Data
{
    public interface ISwapi
    {
        [Get("/api/films")]
        Task<Films> GetFilms();

        [Get("/api/people")]
        Task<People> GetPeople();

        [Get("/api/species")]
        Task<Species> GetSpecies();
    }
}
