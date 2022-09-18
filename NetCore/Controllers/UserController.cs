using Microsoft.AspNetCore.Mvc;
using NetCore.Models;
using NetCore.Repositories;

namespace NetCore.Controllers
{
    public class UserController : Controller
    {
        private static List<User> users = UserRepository.Users;
        // GET: MovieController
        [HttpGet]
        public async Task<ActionResult<List<User>>> Index()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        // GET: MovieController/Details/5
        public async Task<ActionResult<User>> Details(int id)
        {
            var movie = users.Find(h => h.Id == id);
            if (movie == null)
                return BadRequest("Movie not found");
            return Ok(movie);
        }

        // GET: MovieController/Create
        [HttpPost]
        public async Task<ActionResult<List<User>>> AddMovie(User user)
        {
            users.Add(user);
            return Ok(users);
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateMovie(User request)
        {
            var user = users.Find(h => h.Id == request.Id);
            if (user == null)
                return BadRequest("User not found");
            user.Username = request.Username;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Role = request.Role;
            return Ok(users);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> Delete(int id)
        {
            var user = users.Find(h => h.Id == id);
            if (user == null)
                return BadRequest("Movie not found");

            users.Remove(user);
            return Ok(users);
        }
    }
}
