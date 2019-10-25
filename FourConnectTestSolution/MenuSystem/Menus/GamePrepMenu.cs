using System.Collections.Generic;
using FourConnectCore.MenuItems;

namespace FourConnectCore
{
    public class GamePrepMenu : Menu
    {
        public GamePrepMenu()
        {
            MenuItemsDictionary = new Dictionary<string, MenuItem>()
            {
                {"1", new AgainstComputer()},
                {"2", new LocalMultiPlayer()}
            };
        }
    }
}