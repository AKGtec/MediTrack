using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;

namespace MediTrack.Mappings
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            // Entity → DTO
            CreateMap<Message, MessageDto>()
                .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.FirstName + " " + src.Sender.LastName))
                .ForMember(dest => dest.ReceiverName, opt => opt.MapFrom(src => src.Receiver.FirstName + " " + src.Receiver.LastName));

            // DTO → Entity
            CreateMap<CreateMessageDto, Message>()
                .ForMember(dest => dest.SentAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.IsRead, opt => opt.MapFrom(_ => false));

            CreateMap<UpdateMessageStatusDto, Message>();
        }
    }
}
