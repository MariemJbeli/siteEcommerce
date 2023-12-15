using siteEcommerceMovies.Models;
using siteEcommerceMovies.Models.ViewModels;

namespace siteEcommerceMovies.Data.Repository
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAll();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task<int> AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
       Task DeleteMovieAsync(int id);
    }
}
