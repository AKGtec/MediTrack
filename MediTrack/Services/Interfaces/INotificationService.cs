using MediTrack.Models;

namespace MediTrack.Services.Interfaces
{
    public interface INotificationService
    {
        Task<Notification?> GetNotificationByIdAsync(int notificationId);
        Task<IEnumerable<Notification>> GetNotificationsByUserAsync(int userId);
        Task<Notification> SendNotificationAsync(Notification notification);
        Task<bool> MarkAsReadAsync(int notificationId);
    }
}
