using NetCore.Repositories;
using NetCore.Models;
using NetCore.Repositories;

namespace NetCore.Services
{
    public class MovieService
    {
        public MovieService Get(int id)
        {
            var movie = MovieRepository.Movies.FirstOrDefault(x => x.Id == id);

            if (movie is null) return null;
            
            return movie?;
        }

        public List<Movie> List()
        {
            var movies = MovieRepository.Movies;

            return movies;
        }

        public Movie Update(Movie newMovie)
        {
            var oldMovie = MovieRepository.Movies.FirstOrDefault(o=> o.Id == newMovie.Id);

            if (oldMovie == null) return null;

            oldMovie.Title = newMovie.Title;
            oldMovie.Description = newMovie.Description;
            oldMovie.Rating = newMovie.Rating;

            oldMovie.UpdatedDate = DateTime.Now;
            newMovie.UpdatedDate = DateTime.Now;

            newMovie.CreatedDate = oldMovie.CreatedDate;

            return newMovie;
        }

        public bool Delete(int id)
        {
            var oldMovie = MovieRepository.Movies.FirstOrDefault(o => o.Id == newMovie.Id);

            if (oldMovie == null) return false;

            MovieRepository.Movies.Remove(oldMovie);

            return true;
        }
    }
}
