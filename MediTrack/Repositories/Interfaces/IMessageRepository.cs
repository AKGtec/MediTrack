using MediTrack.Models;

namespace MediTrack.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task<Message?> GetByIdAsync(int messageId);
        Task<IEnumerable<Message>> GetConversationAsync(int senderId, int receiverId);
        Task AddAsync(Message message);
        Task UpdateAsync(Message message);
        Task DeleteAsync(int messageId);
    }
}
