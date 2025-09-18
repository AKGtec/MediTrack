using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;

namespace MediTrack.Mappings
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            // Entity → DTO
            CreateMap<Notification, NotificationDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));

            // DTO → Entity
            CreateMap<CreateNotificationDto, Notification>()
                .ForMember(dest => dest.SentAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.IsRead, opt => opt.MapFrom(_ => false));

            CreateMap<UpdateNotificationStatusDto, Notification>();
        }
    }
}
