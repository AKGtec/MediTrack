using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;

namespace MediTrack.Mappings
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            // Entity → DTO
            CreateMap<Patient, PatientDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()));

            // DTO → Entity
            CreateMap<CreatePatientDto, Patient>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<UpdatePatientDto, Patient>();
        }
    }
}
