using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;

namespace MediTrack.Mappings
{
    public class MedicalRecordProfile : Profile
    {
        public MedicalRecordProfile()
        {
            // Entity → DTO
            CreateMap<MedicalRecord, MedicalRecordDto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FirstName + " " + src.Patient.LastName))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FirstName + " " + src.Doctor.LastName))
                .ForMember(dest => dest.Prescriptions, opt => opt.MapFrom(src => src.Prescriptions))
                .ForMember(dest => dest.LabTests, opt => opt.MapFrom(src => src.LabTests));

            // DTO → Entity
            CreateMap<CreateMedicalRecordDto, MedicalRecord>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<UpdateMedicalRecordDto, MedicalRecord>();
        }
    }
}
