using AutoMapper;
using MediTrack.DTOs;
using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implementations
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository _settingsRepository;
        private readonly IMapper _mapper;

        public SettingsService(ISettingsRepository settingsRepository, IMapper mapper)
        {
            _settingsRepository = settingsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SettingDto>> GetAllSettingsAsync()
        {
            var settings = await _settingsRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SettingDto>>(settings);
        }

        public async Task<SettingDto?> GetSettingByKeyAsync(string key)
        {
            var setting = await _settingsRepository.GetByKeyAsync(key);
            if (setting == null) return null;
            return _mapper.Map<SettingDto>(setting);
        }

        public async Task<SettingDto> AddSettingAsync(CreateSettingDto dto)
        {
            var setting = _mapper.Map<Setting>(dto);
            await _settingsRepository.AddAsync(setting);
            return _mapper.Map<SettingDto>(setting);
        }

        public async Task<SettingDto> UpdateSettingAsync(UpdateSettingDto dto)
        {
            var setting = _mapper.Map<Setting>(dto);
            await _settingsRepository.UpdateAsync(setting);
            return _mapper.Map<SettingDto>(setting);
        }

        public async Task<bool> DeleteSettingAsync(int settingId)
        {
            await _settingsRepository.DeleteAsync(settingId);
            return true;
        }
    }
}
