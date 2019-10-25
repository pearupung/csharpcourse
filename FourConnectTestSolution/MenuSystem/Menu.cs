using System;
using System.Collections.Generic;
using System.Linq;
using FourConnectCore.MenuItems;

namespace FourConnectCore
{
    public class Menu
    {
        public string Title { get; set; }
        public int MenuLevel { get; set;}

        public Func<string> GetGraphic { get; set; }
        private const string MenuCommandExit = "E";
        private const string MenuCommandReturnToPrevious = "P";
        private const string MenuCommandReturnToMain = "M";


        private readonly Dictionary<string, MenuItem> _defaultMenuItemsDictionary = new Dictionary<string, MenuItem>()
        {
            {MenuCommandReturnToPrevious, new LeaveMenu()},
            {MenuCommandReturnToMain,new GoToMainMenu()},
            {MenuCommandExit, new Exit()}
        };

        private Dictionary<string, MenuItem> _menuItemsDictionary = new Dictionary<string, MenuItem>();
        public Dictionary<string, MenuItem> MenuItemsDictionary
        {get => _menuItemsDictionary.Concat(_defaultMenuItemsDictionary)
                .ToDictionary(p => p.Key, p => p.Value)
                .Where(pair => pair.Value.IsVisible(MenuLevel))
                .ToDictionary(pair => pair.Key, pair => pair.Value);
            set => _menuItemsDictionary = value;}
        public Dictionary<MenuItem, List<MenuItem>> TogglableMenuItems { get; set; } =
            new Dictionary<MenuItem, List<MenuItem>>();
        public Menu(int menuLevel = 0){MenuLevel = menuLevel;}

        public void ToggleMenuItems(MenuItem menuItem)
        {
            foreach (var item in TogglableMenuItems[menuItem])
            {
                item.IsHidden = false;
            }
            menuItem.IsHidden = true;
        }
    }
}