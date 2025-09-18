using MediTrack.DTOs;

namespace MediTrack.Services.Interfaces
{
    public interface ISettingsService
    {
        Task<IEnumerable<SettingDto>> GetAllSettingsAsync();
        Task<SettingDto?> GetSettingByKeyAsync(string key);
        Task<SettingDto> AddSettingAsync(CreateSettingDto dto);
        Task<SettingDto> UpdateSettingAsync(UpdateSettingDto dto);
        Task<bool> DeleteSettingAsync(int settingId);
    }
}
