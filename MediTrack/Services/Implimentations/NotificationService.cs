using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implementations // Fixed typo: "Implimentations" -> "Implementations"
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<Notification?> GetNotificationByIdAsync(int notificationId)
        {
            return await _notificationRepository.GetByIdAsync(notificationId);
        }

        public async Task<IEnumerable<Notification>> GetNotificationsByUserAsync(int userId)
        {
            return await _notificationRepository.GetByUserIdAsync(userId);
        }

        public async Task<Notification> SendNotificationAsync(Notification notification)
        {
            notification.SentAt = DateTime.UtcNow;
            notification.IsRead = false;
            await _notificationRepository.AddAsync(notification);
            return notification;
        }

        public async Task<bool> MarkAsReadAsync(int notificationId)
        {
            var notification = await _notificationRepository.GetByIdAsync(notificationId);
            if (notification != null && !notification.IsRead)
            {
                notification.IsRead = true;
                await _notificationRepository.UpdateAsync(notification);
                return true;
            }
            return false;
        }
    }
}
