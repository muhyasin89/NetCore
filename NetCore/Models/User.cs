using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NetCore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }


    }
}
