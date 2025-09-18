using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;

namespace MediTrack.Mappings
{
    public class PrescriptionDetailProfile : Profile
    {
        public PrescriptionDetailProfile()
        {
            // Entity → DTO
            CreateMap<PrescriptionDetail, PrescriptionDetailDto>();

            // DTO → Entity
            CreateMap<CreatePrescriptionDetailDto, PrescriptionDetail>();
            CreateMap<UpdatePrescriptionDetailDto, PrescriptionDetail>();
        }
    }
}
