using MediTrack.Data;
using MediTrack.Models;
using MediTrack.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTrack.Repositories.Implementaions
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly MTDbContext _context;

        public SettingsRepository(MTDbContext context)
        {
            _context = context;
        }

        public async Task<Setting?> GetByKeyAsync(string key)
        {
            return await _context.Settings.FirstOrDefaultAsync(s => s.Key == key);
        }

        public async Task<IEnumerable<Setting>> GetAllAsync()
        {
            return await _context.Settings.ToListAsync();
        }

        public async Task AddAsync(Setting setting)
        {
            await _context.Settings.AddAsync(setting);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Setting setting)
        {
            _context.Settings.Update(setting);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int settingId)
        {
            var setting = await _context.Settings.FindAsync(settingId);
            if (setting != null)
            {
                _context.Settings.Remove(setting);
                await _context.SaveChangesAsync();
            }
        }
    }
}
