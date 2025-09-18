using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MediTrack.Mappings
{
    public class AppointmentMappingProfile : Profile
    {
        public AppointmentMappingProfile()
        {
            // Mapping from Appointment entity to AppointmentDto
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient != null ? $"{src.Patient.FirstName} {src.Patient.LastName}" : string.Empty))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor != null ? $"{src.Doctor.FirstName} {src.Doctor.LastName}" : string.Empty));

            // Mapping from CreateAppointmentDto to Appointment entity
            CreateMap<CreateAppointmentDto, Appointment>()
                .ForMember(dest => dest.AppointmentId, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Patient, opt => opt.Ignore())
                .ForMember(dest => dest.Doctor, opt => opt.Ignore())
                .ForMember(dest => dest.MedicalRecord, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore());

            // Reverse mapping (if needed)
            CreateMap<AppointmentDto, Appointment>();
        }
    }
}