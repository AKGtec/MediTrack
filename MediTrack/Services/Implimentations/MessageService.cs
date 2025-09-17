using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implimentations
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Message?> GetMessageByIdAsync(int messageId)
        {
            return await _messageRepository.GetByIdAsync(messageId);
        }

        public async Task<IEnumerable<Message>> GetConversationAsync(int senderId, int receiverId)
        {
            return await _messageRepository.GetConversationAsync(senderId, receiverId);
        }

        public async Task<Message> SendMessageAsync(Message message)
        {
            message.SentAt = DateTime.UtcNow;
            await _messageRepository.AddAsync(message);
            return message;
        }

        public async Task<Message> UpdateMessageAsync(Message message)
        {
            await _messageRepository.UpdateAsync(message);
            return message;
        }

        public async Task<bool> DeleteMessageAsync(int messageId)
        {
            await _messageRepository.DeleteAsync(messageId);
            return true;
        }
    }
}
