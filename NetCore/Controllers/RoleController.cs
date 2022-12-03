using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore.Data;
using NetCore.Models;

namespace NetCore.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize(Roles = "Admin, Super Admin")]
    public class RoleController : Controller
    {
        //the create already in Register
        WebAPIContext _context;
        public RoleController(WebAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Role>>> index()
        {
            return Ok(await _context.Roles.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetById(int id)
        {
            var Role = await _context.Roles.FindAsync(id);

            return Ok(Role);
        }

        [HttpPut]
        public async Task<ActionResult<Role>> UpdateUser(int id, UserUpdateDTO Role)
        {
            var findRole = await _context.Roles.FindAsync(id);

            if (findRole == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            findRole.Name = Role.Name;
           

            _context.Entry(findRole).State = EntityState.Modified;

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

            return Ok(findRole);
        }

        [HttpDelete]
        public async Task<ActionResult<Role>> Delete(int id, bool? saveChangesError = false)
        {
            var Role = await _context.Roles.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (Role == null)
            {
                return NotFound();
            }

            try
            {
                _context.Entry(Role).State = EntityState.Deleted;
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
