using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using MediTrack.Services.Interfaces;

namespace MediTrack.Services.Implementations
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository _settingsRepository;

        public SettingsService(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public async Task<Setting?> GetSettingByKeyAsync(string key)
        {
            return await _settingsRepository.GetByKeyAsync(key);
        }

        public async Task<IEnumerable<Setting>> GetAllSettingsAsync()
        {
            return await _settingsRepository.GetAllAsync();
        }

        public async Task<Setting> AddSettingAsync(Setting setting)
        {
            await _settingsRepository.AddAsync(setting);
            return setting;
        }

        public async Task<Setting> UpdateSettingAsync(Setting setting)
        {
            await _settingsRepository.UpdateAsync(setting);
            return setting;
        }

        public async Task<bool> DeleteSettingAsync(int settingId)
        {
            await _settingsRepository.DeleteAsync(settingId);
            return true;
        }
    }
}
