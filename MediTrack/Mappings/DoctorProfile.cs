using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;

namespace MediTrack.Mappings
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            // Entity → DTO
            CreateMap<Doctor, DoctorDto>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            // DTO → Entity
            CreateMap<CreateDoctorDto, Doctor>();
            CreateMap<UpdateDoctorDto, Doctor>();
        }
    }
}
