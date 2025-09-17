using MediTrack.Models;

namespace MediTrack.Repositories.Interfaces
{
    public interface ISettingsRepository
    {
        Task<Setting?> GetByKeyAsync(string key);
        Task<IEnumerable<Setting>> GetAllAsync();
        Task AddAsync(Setting setting);
        Task UpdateAsync(Setting setting);
        Task DeleteAsync(int settingId);
    }
}
