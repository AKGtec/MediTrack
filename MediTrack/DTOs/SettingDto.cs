namespace MediTrack.DTOs
{
    // Output DTO
    public class SettingDto
    {
        public int SettingId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }

    // Input DTO for creation
    public class CreateSettingDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    // Input DTO for updates
    public class UpdateSettingDto
    {
        public int SettingId { get; set; }
        public string Value { get; set; }
    }
}
