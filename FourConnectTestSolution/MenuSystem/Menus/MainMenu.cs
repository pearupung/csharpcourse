using System.Collections.Generic;
using FourConnectCore.MenuItems;

namespace FourConnectCore
{
    public class MainMenu : Menu
    {
        public MainMenu()
        {
            MenuItemsDictionary = new Dictionary<string, MenuItem>()
            {
                {"1", new GoToGamePrepMenu()},
                {"2", new LoadGame()},
                {"3", new Settings()},
            };
        }
    }
}