using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace FourConnectCore
{
    public class Settings
    {
        private int[] settings;

        private static int _selectedSetting = 0;
        private static Settings _settings = new Settings();

        private Settings()
        {
            settings = new[] {5, 5};
        }

        public static Settings GetSettings()
        {
            return _settings;
        }

        public string IncreaseValue()
        {
            settings[_selectedSetting] += 1;
            return "";
        }

        public string DecreaseValue()
        {
            if (settings[_selectedSetting] > 4)
            {
                settings[_selectedSetting]--;
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
            return settings[1];
        }

        public int GetBoardHeight()
        {
            return settings[0];
        }

        public override string ToString()
        {
            return $"Board width: {settings[0]}, board height: {settings[1]}";
        }
    }
}