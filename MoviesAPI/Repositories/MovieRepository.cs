using MoviesAPI.Data;
using MoviesAPI.Models;
using MoviesAPI.Repositories.Interfaces;

namespace MoviesAPI.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateMovie(Movie movie)
        {
            movie.DateOfCreation= DateTime.Now;
            _context.Movies.Add(movie);
            return Save();
        }

        public bool DeleteMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
            return Save();
        }

        public bool ExistMovie(int id)
        {
            return _context.Movies.Any(c => c.Id == id);
        }

        public bool ExistMovie(string name)
        {
            return _context.Movies.Any(c => c.Name == name);
        }

        public Movie GetMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(c => c.Id == id);
            return movie;
        }

        public ICollection<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        public ICollection<Movie> GetMoviesInCategory(int categoryId)
        {
            return _context.Movies.Where(c=>c.CategoryId == categoryId).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool UpdateMovie(Movie movie)
        {
            movie.DateOfCreation = DateTime.Now;
            _context.Movies.Update(movie);
            return Save();
        }
    }
}
