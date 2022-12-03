using NetCore.Models;
using System.Security.Claims;

namespace NetCore.Service.UserService
{
    public class UserService: IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
       public string GetMyName()
        {
            string result = string.Empty;

            if(_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }

     
    }
}
