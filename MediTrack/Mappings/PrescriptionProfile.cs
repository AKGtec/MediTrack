using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;

namespace MediTrack.Mappings
{
    public class PrescriptionProfile : Profile
    {
        public PrescriptionProfile()
        {
            CreateMap<Prescription, PrescriptionDto>()
                .ForMember(dest => dest.PrescriptionDetailIds,
                           opt => opt.MapFrom(src => src.Details != null ? src.Details.Select(d => d.PrescriptionDetailId) : new List<int>()));

            CreateMap<CreatePrescriptionDto, Prescription>()
                .ForMember(dest => dest.PrescribedDate, opt => opt.MapFrom(src => src.PrescribedDate ?? DateTime.UtcNow));
        }
    }
}
