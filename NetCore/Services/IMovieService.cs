using NetCore.Models;

namespace NetCore.Services
{
    public interface IMovieService
    {
        public Movie Get(int id);
        public Movie Create(Movie movie);
        public Movie Update(Movie movie);
        public List<Movie> List();
        public bool Delete(int id);
    }
}
