using Microsoft.EntityFrameworkCore;
using World.Api.Model;

namespace World.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        { 

        }

        public DbSet<Students> students { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }




    }
}
