using MediTrack.DTOs;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SettingDto>>> GetAllSettings()
        {
            var settings = await _settingsService.GetAllSettingsAsync();
            return Ok(settings);
        }

        [HttpGet("Key/{key}")]
        public async Task<ActionResult<SettingDto>> GetSettingByKey(string key)
        {
            var setting = await _settingsService.GetSettingByKeyAsync(key);
            if (setting == null) return NotFound();
            return Ok(setting);
        }

        [HttpPost]
        public async Task<ActionResult<SettingDto>> AddSetting([FromBody] CreateSettingDto dto)
        {
            var created = await _settingsService.AddSettingAsync(dto);
            return CreatedAtAction(nameof(GetSettingByKey), new { key = created.Key }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SettingDto>> UpdateSetting(int id, [FromBody] UpdateSettingDto dto)
        {
            if (dto == null || dto.SettingId != id) return BadRequest();
            var updated = await _settingsService.UpdateSettingAsync(dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteSetting(int id)
        {
            var result = await _settingsService.DeleteSettingAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
