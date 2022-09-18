using NetCore.Models;

namespace NetCore.Services
{
    public class IUserService
    {
        public User Get(UserLogin userLogin);
    }
}
