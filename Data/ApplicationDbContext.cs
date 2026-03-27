using Microsoft.EntityFrameworkCore;
using SmartGymAPI.Model;

namespace SmartGymAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<User>Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
