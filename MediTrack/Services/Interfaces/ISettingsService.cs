using MediTrack.Models;

namespace MediTrack.Services.Interfaces
{
    public interface ISettingsService
    {
        Task<Setting?> GetSettingByKeyAsync(string key);
        Task<IEnumerable<Setting>> GetAllSettingsAsync();
        Task<Setting> AddSettingAsync(Setting setting);
        Task<Setting> UpdateSettingAsync(Setting setting);
        Task<bool> DeleteSettingAsync(int settingId);
    }
}
