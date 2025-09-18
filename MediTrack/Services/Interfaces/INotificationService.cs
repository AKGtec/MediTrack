using MediTrack.DTOs;

namespace MediTrack.Services.Interfaces
{
    public interface INotificationService
    {
        Task<NotificationDto?> GetNotificationByIdAsync(int notificationId);
        Task<IEnumerable<NotificationDto>> GetNotificationsByUserAsync(int userId);
        Task<NotificationDto> SendNotificationAsync(CreateNotificationDto dto);
        Task<NotificationDto?> MarkAsReadAsync(int notificationId, UpdateNotificationStatusDto dto);
    }
}
