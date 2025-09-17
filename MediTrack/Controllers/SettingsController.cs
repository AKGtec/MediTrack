using MediTrack.Models;
using MediTrack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsService _settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        // GET: api/Settings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Setting>>> GetAllSettings()
        {
            var settings = await _settingsService.GetAllSettingsAsync();
            return Ok(settings);
        }

        // GET: api/Settings/Key/SomeKey
        [HttpGet("Key/{key}")]
        public async Task<ActionResult<Setting>> GetSettingByKey(string key)
        {
            var setting = await _settingsService.GetSettingByKeyAsync(key);
            if (setting == null)
                return NotFound();

            return Ok(setting);
        }

        // POST: api/Settings
        [HttpPost]
        public async Task<ActionResult<Setting>> AddSetting([FromBody] Setting setting)
        {
            if (setting == null)
                return BadRequest("Setting cannot be null.");

            var createdSetting = await _settingsService.AddSettingAsync(setting);
            return CreatedAtAction(nameof(GetSettingByKey), new { key = createdSetting.Key }, createdSetting);
        }

        // PUT: api/Settings/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Setting>> UpdateSetting(int id, [FromBody] Setting setting)
        {
            if (setting == null || setting.SettingId != id)
                return BadRequest("Invalid setting data.");

            var updatedSetting = await _settingsService.UpdateSettingAsync(setting);
            return Ok(updatedSetting);
        }

        // DELETE: api/Settings/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteSetting(int id)
        {
            var result = await _settingsService.DeleteSettingAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
