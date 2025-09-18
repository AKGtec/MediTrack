using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implimentations
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<MessageDto?> GetMessageByIdAsync(int messageId)
        {
            var message = await _messageRepository.GetByIdAsync(messageId);
            return message == null ? null : _mapper.Map<MessageDto>(message);
        }

        public async Task<IEnumerable<MessageDto>> GetConversationAsync(int senderId, int receiverId)
        {
            var messages = await _messageRepository.GetConversationAsync(senderId, receiverId);
            return _mapper.Map<IEnumerable<MessageDto>>(messages);
        }

        public async Task<MessageDto> SendMessageAsync(CreateMessageDto dto)
        {
            var message = _mapper.Map<Message>(dto);
            await _messageRepository.AddAsync(message);
            return _mapper.Map<MessageDto>(message);
        }

        public async Task<MessageDto?> UpdateMessageStatusAsync(int id, UpdateMessageStatusDto dto)
        {
            var existing = await _messageRepository.GetByIdAsync(id);
            if (existing == null)
                return null;

            _mapper.Map(dto, existing);
            await _messageRepository.UpdateAsync(existing);
            return _mapper.Map<MessageDto>(existing);
        }

        public async Task<bool> DeleteMessageAsync(int messageId)
        {
            await _messageRepository.DeleteAsync(messageId);
            return true;
        }
    }
}
