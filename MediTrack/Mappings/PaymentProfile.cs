using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;

namespace MediTrack.Mappings
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            // Entity → DTO
            CreateMap<Payment, PaymentDto>();

            // DTO → Entity
            CreateMap<CreatePaymentDto, Payment>()
                .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<UpdatePaymentDto, Payment>()
                .ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => src.PaymentDate ?? DateTime.UtcNow));
        }
    }
}
