using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Domain;
using Microsoft.VisualBasic.CompilerServices;

namespace FourConnectCore
{
    public class Settings
    {
        public GameSetting[] settings;

        public int SelectedSetting = 0;
        private static readonly Settings _settings = new Settings();

        private Settings()
        {
            using (var ctx = new AppDbContext())
            {
                settings = ctx.GameSettings.ToArray();
            }
        }

        public static Settings GetSettings()
        {
            return _settings;
        }

        public string IncreaseValue()
        {
            var gameSetting = settings[SelectedSetting];
            if (gameSetting.Value < gameSetting.MaxValue)
            {
                gameSetting.Value++;
            }
            return "";
        }

        public string DecreaseValue()
        {
            var gameSetting = settings[SelectedSetting];
            if (gameSetting.Value > gameSetting.MinValue)
            {
                gameSetting.Value--;
            }

            return "";
        }

        public string ToggleValueSelected()
        {
            SelectedSetting = (SelectedSetting+1) % settings.Length;
            return "";
        }

        public int GetBoardWidth()
        {
            return settings.Where(s => s.Name.Equals("Board Width")).ToArray()[0].Value;
        }

        public int GetBoardHeight()
        {
            return settings.Where(s => s.Name.Equals("Board Height")).ToArray()[0].Value;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (var index = 0; index < settings.Length; index++)
            {
                var pointer = index == SelectedSetting ? "> " : "  ";
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