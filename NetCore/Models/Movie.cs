namespace NetCore.Models
{
    public class Movie
    {

        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public double Rating { get; set; } = 0;
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }


    }
}
