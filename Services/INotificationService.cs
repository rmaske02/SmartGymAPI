using SmartGymAPI.Model;

namespace SmartGymAPI.Services
{
    public interface INotificationService
    {
        Task AddNotification(int userId,string message);
        Task<List<Notification>>GetUserNotifications(int userId);
        Task MarkAsRead(int notificationId);
    }
}
