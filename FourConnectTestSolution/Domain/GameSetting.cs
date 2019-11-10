using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class GameSetting
    {
        public int GameSettingId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public int Value { get; set; } = default!;

        public int MaxValue { get; set; } = default!;
        public int MinValue { get; set; } = default!;
    }
}