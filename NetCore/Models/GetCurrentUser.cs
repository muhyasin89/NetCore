namespace NetCore.Models
{
    public class GetCurrentUser
    {
        public string UserName { get; set; } = string.Empty;
        public int UserId { get; set; } 
        public string UserRole { get; set; } = string.Empty;

    }
}
