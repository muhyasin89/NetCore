using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using NetCore.Models;


namespace NetCore.Repositories
{
    public class UserRepository
    {

        public static List<User> Users = new()
        {
            new()
            {
                Username="luke_admin",
                EmailAddress="luke.admin@gmail.com",
                Password="123",
                Role="Administrator",
                FirstName="luke",
                LastName="admin",
                CreatedDate=DateTime.Now,
                UpdatedDate=DateTime.Now
            },
            new()
            {
                Username="lydia_standard",
                EmailAddress="lydia_standard@gmail.com",
                Password="123",
                Role="Student",
                FirstName="luke",
                LastName="admin",
                CreatedDate=DateTime.Now,
                UpdatedDate=DateTime.Now
            }
        };
    }
}
