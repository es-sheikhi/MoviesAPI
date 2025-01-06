using MoviesAPI.Models;
using MoviesAPI.Models.DTOs;

namespace MoviesAPI.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        ICollection<Movie> GetMovies();
        ICollection<Movie> GetMoviesInCategory(int categoryId);
        Movie GetMovie(int id);
        bool ExistMovie(int id);
        bool ExistMovie(string name);

        bool CreateMovie(Movie movie);
        bool UpdateMovie(Movie movie);
        bool DeleteMovie(Movie movie);
        bool Save();
    }
}
