using Microsoft.EntityFrameworkCore;
using NetCore.Models;
using System.Xml.Linq;

namespace NetCore.Data
{
    public class WebAPIContext: DbContext
    {

        public WebAPIContext(DbContextOptions<WebAPIContext> options): base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            
            modelBuilder.Entity<Role>().HasData(

                new Role { Id = 1, Name ="Super Admin"},
                new Role { Id = 2, Name = "Admin" },
                new Role { Id = 3, Name = "User" }
                );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }
    }
}
