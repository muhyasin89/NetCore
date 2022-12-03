
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore.Data;
using NetCore.Models;
using System.Security.Claims;



namespace NetCore.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BlogPostController : Controller
    {
        //the create already in Register
        WebAPIContext _context;
        private string userId;

        public BlogPostController(WebAPIContext context, IServiceCollection services, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            services.AddHttpContextAccessor();
            userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        [HttpGet]
        public async Task<ActionResult<List<BlogPost>>> index()
        {
            return Ok(await _context.BlogPost.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPost>> GetById(int id)
        {
            var BlogPost = await _context.BlogPost.FindAsync(id);

            return Ok(BlogPost);
        }

        [HttpPut]
        public async Task<ActionResult<BlogPost>> UpdateUser(int id, BlogPost BlogPost)
        {
            var findBlogPost = await _context.BlogPost.FindAsync(id);

            if (findBlogPost == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            findBlogPost.Topic = BlogPost.Topic;
            findBlogPost.Description = BlogPost.Description;
            findBlogPost.UpdatedDate = DateTime.Now;
            findBlogPost.User = await _context.Users.FindAsync(userId);


            _context.Entry(findBlogPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to save change. " +
                        "Try Again, if you have problem persists, " +
                        "Contact your system administrator");
            }

            return Ok(findBlogPost);
        }

        [HttpDelete]
        public async Task<ActionResult<BlogPost>> Delete(int id, bool? saveChangesError = false)
        {
            var BlogPost = await _context.BlogPost.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (BlogPost == null)
            {
                return NotFound();
            }

            try
            {
                _context.Entry(BlogPost).State = EntityState.Deleted;
                await _context.SaveChangesAsync();



            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to save change. " +
                        "Try Again, if you have problem persists, " +
                        "Contact your system administrator");
            }

            return Ok();
        }
    }
}
