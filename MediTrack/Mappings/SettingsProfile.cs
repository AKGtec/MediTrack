using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;

namespace MediTrack.Mappings
{
    public class SettingsProfile : Profile
    {
        public SettingsProfile()
        {
            CreateMap<Setting, SettingDto>().ReverseMap();
            CreateMap<CreateSettingDto, Setting>();
            CreateMap<UpdateSettingDto, Setting>();
        }
    }
}
