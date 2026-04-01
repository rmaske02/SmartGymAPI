using Microsoft.EntityFrameworkCore;
using SmartGymAPI.Data;

namespace SmartGymAPI.Services
{
    public class DashboardService:IDashboardService
    {
        private readonly ApplicationDbContext _context;
        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<object>GetStats()
        {
            var totalUsers = await _context.Users.CountAsync();
            var totalTrainers = await _context.Trainers.CountAsync();
            var totalBookings = await _context.Bookings.CountAsync();
            var activeSubscriptions = await _context.Subscriptions.CountAsync(s=>s.IsActive && s.EndDate > DateTime.UtcNow);

            return new
            {
                TotalUsers = totalUsers,
                TotalTrainers = totalTrainers,
                TotalBookings = totalBookings,
                ActiveSubscriptions = activeSubscriptions
            };
        }
    }
}
