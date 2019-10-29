using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace FourConnectCore
{
    public class Settings
    {
        class Setting
        {
            public string? Name { get; set; }
            public int Value { get; set; }
        }
        private Setting[] settings;

        private static int _selectedSetting = 0;
        private static Settings _settings = new Settings();

        private Settings()
        {
            settings = new[] {new Setting()
            {
                Name = "Board height",
                Value = 4
            }, new Setting()
            {
                Name = "Board width",
                Value = 4
            }};
        }

        public static Settings GetSettings()
        {
            return _settings;
        }

        public string IncreaseValue()
        {
            settings[_selectedSetting].Value++;
            return "";
        }

        public string DecreaseValue()
        {
            if (settings[_selectedSetting].Value > 4)
            {
                settings[_selectedSetting].Value--;
            }

            return "";
        }

        public string ToggleValueSelected()
        {
            _selectedSetting = (_selectedSetting+1) % settings.Length;
            return "";
        }

        public int GetBoardWidth()
        {
            return settings[1].Value;
        }

        public int GetBoardHeight()
        {
            return settings[0].Value;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (var index = 0; index < settings.Length; index++)
            {
                var pointer = index == _selectedSetting ? "> " : "  ";
                builder.Append(pointer);
                var setting = settings[index];
                builder.Append(setting.Name);
                builder.Append("\t| ");
                builder.Append(setting.Value);
                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}