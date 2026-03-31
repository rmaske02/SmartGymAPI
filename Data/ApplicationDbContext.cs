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
        public DbSet<Trainer>Trainers { get; set; }
        public DbSet<Booking>Bookings { get; set; }
        public DbSet<MembershipPlan>MembershipPlans { get; set; }
        public DbSet<Subscription>Subscriptions { get; set; }
    }
}
