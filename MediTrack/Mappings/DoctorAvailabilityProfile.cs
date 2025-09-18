using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;

namespace MediTrack.Mappings
{
    public class DoctorAvailabilityProfile : Profile
    {
        public DoctorAvailabilityProfile()
        {
            // Entity -> DTO
            CreateMap<DoctorAvailability, DoctorAvailabilityDto>()
                .ForMember(dest => dest.DoctorName,
                           opt => opt.MapFrom(src => src.Doctor.FirstName));

            // DTO -> Entity
            CreateMap<CreateDoctorAvailabilityDto, DoctorAvailability>();
            CreateMap<UpdateDoctorAvailabilityDto, DoctorAvailability>();
        }
    }
}
