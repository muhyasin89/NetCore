namespace NetCore.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Topic { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

        public User? User { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
