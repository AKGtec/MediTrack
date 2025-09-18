using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;

namespace MediTrack.Mappings
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            // Entity → DTO
            CreateMap<Invoice, InvoiceDto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FirstName + " " + src.Patient.LastName))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FirstName + " " + src.Doctor.LastName))
                .ForMember(dest => dest.Payments, opt => opt.MapFrom(src => src.Payments));

            // DTO → Entity
            CreateMap<CreateInvoiceDto, Invoice>();
            CreateMap<UpdateInvoiceStatusDto, Invoice>();
        }
    }
}
