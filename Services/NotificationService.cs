//using SmartGymAPI.Data;
//using SmartGymAPI.Model;

//namespace SmartGymAPI.Services
//{
//    public class NotificationService:INotificationService
//    {
//        private readonly ApplicationDbContext _context;
//        public NotificationService(ApplicationDbContext context)
//        {
//            _context = context;
//        }
//        public async Task AddNotification(int userId,string message)
//        {
//            var notification = new Notification
//            {
//                UserId = userId,
//                Message = message,
//                CreatedAt = DateTime.Now,
//                IsRead = false
//            };
//            _context.Notifications.Add(notification);
//            await _context.SaveChangesAsync();
//        }
//        public async Task<List<Notification>> GetUserNotifications(int userId)
//        {
//            return await _context.Notifications
//                .Where(n => n.UserId == userId)
//                .OrderByDescending(n => n.CreatedAt)
//                .ToListAsync();
//        }

//        public async Task MarkAsRead(int notificationId)
//        {   
//            var notification = await _context.Notifications.FindAsync(notificationId);
//            if (notification != null)
//            {
//                notification.IsRead = true;
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
using SmartGymAPI.Data;
using SmartGymAPI.Model;
using SmartGymAPI.Services;
using Microsoft.EntityFrameworkCore;

public class NotificationService : INotificationService
{
    private readonly ApplicationDbContext _context;

    public NotificationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddNotification(int userId, string message)
    {
        var notification = new Notification
        {
            UserId = userId,
            Message = message,
            CreatedAt = DateTime.UtcNow,
            IsRead = false
        };

        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Notification>> GetUserNotifications(int userId)
    {
        return await _context.Notifications
            .Where(n => n.UserId == userId)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();
    }

    public async Task MarkAsRead(int notificationId)
    {
        var notification = await _context.Notifications.FindAsync(notificationId);
        if (notification != null)
        {
            notification.IsRead = true;
            await _context.SaveChangesAsync();
        }
    }
}