using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;

namespace MediTrack.Mappings
{
    public class AuditLogMappingProfile : Profile
    {
        public AuditLogMappingProfile()
        {
            // Mapping from AuditLog entity to AuditLogDto
            CreateMap<AuditLog, AuditLogDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src =>
                    src.User != null ? $"{src.User.FirstName} {src.User.LastName}".Trim() : string.Empty));

            // Mapping from CreateAuditLogDto to AuditLog entity
            CreateMap<CreateAuditLogDto, AuditLog>()
                .ForMember(dest => dest.LogId, opt => opt.Ignore())
                .ForMember(dest => dest.Timestamp, opt => opt.Ignore()) // Set in service
                .ForMember(dest => dest.User, opt => opt.Ignore());

            // Reverse mapping (if needed)
            CreateMap<AuditLogDto, AuditLog>();
        }
    }
}