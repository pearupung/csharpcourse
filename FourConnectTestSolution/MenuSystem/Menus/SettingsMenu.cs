using System.Collections.Generic;
using FourConnectCore.MenuItems;

namespace FourConnectCore
{
    public class SettingsMenu : Menu
    {
        public SettingsMenu()
        {
            MenuItemsDictionary = new Dictionary<string, MenuItem>()
            {
                {"1", new ToggleValue()},
                {"2", new Increment()},
                {"3", new Decrement()}
            };
        }
    }
}