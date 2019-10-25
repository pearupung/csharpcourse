using System.Collections.Generic;
using FourConnectCore.MenuItems;

namespace FourConnectCore
{
    public class GameMenu : Menu
    {
        public GameMenu()
        {
            MenuItemsDictionary = new Dictionary<string, MenuItem>()
            {
                {"1", new PlayX()},
                {"2", new PlayO()},
                {"3", new GoLeftOneColumn()},
                {"4", new GoRightOneColumn()},
                {"5", new SaveGame()},
                {"6", new Exit()}
            };
        }
    }
}