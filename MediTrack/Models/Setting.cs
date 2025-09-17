using System.ComponentModel.DataAnnotations;

namespace MediTrack.Models
{
    public class Setting
    {
        [Key]
        public int SettingId { get; set; }

        [Required, MaxLength(200)]
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
