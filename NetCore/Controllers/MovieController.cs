using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.Repositories;
using NetCore.Models;

namespace NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {

        private static List<Movie> movies = MovieRepository.Movies;
        // GET: MovieController
        [HttpGet]
        public async Task<ActionResult<List<Movie>>> Index()
        {
            return Ok(movies);
        }

        [HttpGet("{id}")]
        // GET: MovieController/Details/5
        public async Task<ActionResult<Movie>> Details(int id)
        {
            var movie = movies.Find(h => h.Id == id);
            if (movie == null)
                return BadRequest("Movie not found");
            return Ok(movie);
        }

        // GET: MovieController/Create
        [HttpPost]
        public async Task<ActionResult<List<Movie>>> AddMovie(Movie movie)
        {
            movies.Add(movie);
            return Ok(movies);
        }

        [HttpPut]
        public async Task<ActionResult<List<Movie>>> UpdateMovie(Movie request)
        {
            var movie = movies.Find(h => h.Id == request.Id);
            if (movie == null)
                return BadRequest("Movie not found");
            movie.Title = request.Title;
            movie.Description = request.Description;
            movie.Rating = request.Rating;
            return Ok(movies);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Movie>>> Delete(int id)
        {
            var movie = movies.Find(h => h.Id == id);
            if (movie == null)
                return BadRequest("Movie not found");

            movies.Remove(movie);
            return Ok(movies);
        }
    }
}
