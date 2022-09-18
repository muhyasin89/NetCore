namespace NetCore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;

        public string EmailAddress { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;

        public string Role { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}
