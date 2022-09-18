using NetCore.Models;
using NetCore.Repositories;

namespace NetCore.Services
{
    public class UserService:IUserService
    {
        public User Get(UserLogin userLogin)
        {
            User user = UserRepository.Users.FirstOrDefault(o => o.Username.Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase)
            && o.Password.Equals(UserLogin.password));

            return user;
        }
    }
}
