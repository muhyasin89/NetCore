using Microsoft.EntityFrameworkCore;


namespace IssueApp
{
    public class IssueDataContext: DbContext
    {
        public IssueDataContext(DbContextOptions<IssueDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();
        }

        public DbSet<Issue> Issues { get; set; }
    }
}
