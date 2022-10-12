using Microsoft.EntityFrameworkCore;
using NetCore.Model;

namespace NetCore.Data
{
    public class IssueDbContext: DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options) : base(options)
        {

        }

        public DbSet<Issue> Issues { get; set; }
    }
}
