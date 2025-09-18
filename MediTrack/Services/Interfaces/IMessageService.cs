using MediTrack.DTOs;

namespace MediTrack.Services.Interfaces
{
    public interface IMessageService
    {
        Task<MessageDto?> GetMessageByIdAsync(int messageId);
        Task<IEnumerable<MessageDto>> GetConversationAsync(int senderId, int receiverId);
        Task<MessageDto> SendMessageAsync(CreateMessageDto dto);
        Task<MessageDto?> UpdateMessageStatusAsync(int id, UpdateMessageStatusDto dto);
        Task<bool> DeleteMessageAsync(int messageId);
    }
}
