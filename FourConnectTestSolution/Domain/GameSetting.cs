using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class GameSetting
    {
        public int GameSettingId { get; set; } = default!;
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        
        public int Value { get; set; } = default!;
        [Required]

        public int MaxValue { get; set; } = default!;
        [Required]
        public int MinValue { get; set; } = default!;
    }
}