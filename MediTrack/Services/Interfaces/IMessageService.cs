using MediTrack.Models;

namespace MediTrack.Services.Interfaces
{
    public interface IMessageService
    {
        Task<Message?> GetMessageByIdAsync(int messageId);
        Task<IEnumerable<Message>> GetConversationAsync(int senderId, int receiverId);
        Task<Message> SendMessageAsync(Message message);
        Task<bool> DeleteMessageAsync(int messageId);
    }
}
