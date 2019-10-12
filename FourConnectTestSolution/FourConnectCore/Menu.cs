using System.Collections.Generic;

namespace FourConnectCore
{
    public class Menu
    {
        private int _menuLevel;

        private const string MenuCommandExit = "X";
        private const string MenuCommandReturnToPrevious = "P";
        private const string MenuCommandReturnToMain = "M";

        private Dictionary<string, MenuItem> _menuItemsDictionary = new Dictionary<string, MenuItem>();

        public Menu(int menuLevel = 0)
        {
            _menuLevel = menuLevel;
        }
        
        public string Title { get; set; }
    }
}