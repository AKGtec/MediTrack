using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;

namespace MediTrack.Mappings
{
    public class LabTestProfile : Profile
    {
        public LabTestProfile()
        {
            // Entity → DTO
            CreateMap<LabTest, LabTestDto>();

            // DTO → Entity
            CreateMap<CreateLabTestDto, LabTest>()
                .ForMember(dest => dest.TestDate, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<UpdateLabTestDto, LabTest>()
                .ForMember(dest => dest.TestDate, opt => opt.MapFrom(src => src.TestDate ?? DateTime.UtcNow));
        }
    }
}
