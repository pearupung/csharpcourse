using System.Collections.Generic;
using FourConnectCore.MenuItems;

namespace FourConnectCore
{
    public class GameMenu : Menu
    {
        public GameMenu()
        {
            var playX = new PlayX();
            var playO = new PlayO();
            MenuItemsDictionary = new Dictionary<string, MenuItem>()
            {
                {"1", playX},
                {"2", playO},
                {"3", new GoLeftOneColumn()},
                {"4", new GoRightOneColumn()},
                {"5", new SaveGame()}
            };
            
            TogglableMenuItems = new Dictionary<MenuItem, List<MenuItem>>()
            {
                {playX, new List<MenuItem>() {playO}},
                {playO, new List<MenuItem>() {playX}}
            };
        }
    }
}