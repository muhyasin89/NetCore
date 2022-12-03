using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore.Data;
using NetCore.Models;
using System.Security.Cryptography;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        public static User user = new User();
        WebAPIContext _webAPIContext;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthController(IConfiguration configuration, WebAPIContext context, IUserService userService) 
        {
            _configuration = configuration;
            _webAPIContext = context;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegisterDTO request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var findUser = await _webAPIContext.Users.FirstOrDefaultAsync(p => p.Email == request.Email);
            if(findUser != null)
            {
                return BadRequest("Email anda suda terdaftar");
            }

            var findRole = await _webAPIContext.Roles.FirstOrDefaultAsync(p => p.Name == "User");

            user.Email = request.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PhoneNumber = request.PhoneNumber;
            user.DOB = request.DOB;
            user.Role = findRole;

            _webAPIContext.Users.Add(user);


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try {
                await _webAPIContext.SaveChangesAsync();
                
            }
            catch(DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to save change. " +
                    "Try Again, if you have problem persists, "+
                    "Contact your system administrator");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLoginDTO request)
        {

            var user = await _webAPIContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if(user == null)
            {
                return BadRequest("User not found");
            }

            if(!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong Password");
            }

            string token = CreateToken(user);
            TokenReturn tokenReturn = new TokenReturn()
            {
                Token = token,
                RefreshToken = "",
                ExpiredIn = 0
            };


            return Ok(tokenReturn);
        }

        [HttpGet, Authorize]
        public async Task<ActionResult<GetCurrentUser>> GetMe()
        {
            //String userName = User?.Identity?.Name;

            String userName = _userService.GetMyName();
            User user = await _webAPIContext.Users.FirstOrDefaultAsync(x => x.Name == userName);
            if(user == null)
            {
                throw new Exception("User is null with that name");
            }
            String role = "User";
            if (user.Role != null)
            {
                role = user.Role.Name;
            }
            
            

            GetCurrentUser getCurrentUser = new
            GetCurrentUser
            ()
            {
                UserId = user.Id,
                UserName = userName,
                UserRole = role
            };

            return Ok(getCurrentUser);
        }

        private string CreateToken(User user)
        {
            string role = "User";
            if(user.Role != null)
            {
                 role = user.Role.Name;
            }
           
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value
                ));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
