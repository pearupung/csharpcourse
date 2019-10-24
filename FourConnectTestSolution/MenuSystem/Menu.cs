using System;
using System.Collections.Generic;
using System.Linq;

namespace FourConnectCore
{
    public class Menu
    {
        private int _menuLevel;

        public Func<string> GetGraphic { get; set; }
        private const string MenuCommandExit = "E";
        private const string MenuCommandReturnToPrevious = "P";
        private const string MenuCommandReturnToMain = "M";

        private Dictionary<string, MenuItem> _defaultMenuItemsDictionary = new Dictionary<string, MenuItem>(){
        {
            MenuCommandReturnToPrevious,
            new MenuItem() {Title = "Return to Previous Menu", VisibleFromLevel = 2}
        },
        {
            MenuCommandReturnToMain,
            new MenuItem() {Title = "Return to Main Menu", VisibleFromLevel = 1}
        },
        {
            MenuCommandExit,
            new MenuItem() {Title = "Exit", VisibleFromLevel = 0}
        }};


        private Dictionary<string, MenuItem> _menuItemsDictionary = new Dictionary<string, MenuItem>();

        public Dictionary<MenuItem, List<MenuItem>> TogglableMenuItems { get; set; } =
            new Dictionary<MenuItem, List<MenuItem>>();
            

        public Menu(int menuLevel = 0)
        {
            _menuLevel = menuLevel;
        }
        
        public string Title { get; set; }

        public Dictionary<string, MenuItem> MenuItemsDictionary
        {
            get => _menuItemsDictionary.Concat(_defaultMenuItemsDictionary)
                .ToDictionary(p => p.Key, p => p.Value);
            set { _menuItemsDictionary = value; }
        }

        public string Run()
        {
            var command = "";
            do
            {
                Console.Clear();
                if (GetGraphic != null)
                {
                    Console.WriteLine(GetGraphic());
                }
                Console.WriteLine(Title);
                Console.WriteLine("=======================");

                foreach (var menuItem in MenuItemsDictionary)
                {

                    if (menuItem.Value.IsVisible(_menuLevel))
                    {
                        Console.Write(menuItem.Key);
                        Console.Write(" ");
                        Console.WriteLine(menuItem.Value);
                    }
                }
                
                Console.WriteLine("--------------");
                Console.Write(">");

                command = Console.ReadLine()?.Trim().ToUpper() ?? "";

                var returnCommand = "";

                if (MenuItemsDictionary.ContainsKey(command))
                {
                    var menuItem = MenuItemsDictionary[command];
                    if (menuItem.IsExecutable(_menuLevel))
                    {
                        returnCommand = menuItem.CommandToExecute();
                    }

                    if (TogglableMenuItems.ContainsKey(menuItem))
                    {
                        foreach (var item in TogglableMenuItems[menuItem])
                        {
                            item.IsHidden = false;
                        }

                        menuItem.IsHidden = true;
                    }
                }

                if (returnCommand == MenuCommandExit ||
                    returnCommand == MenuCommandReturnToMain && _menuLevel != 0) return returnCommand;
            } while (command != MenuCommandExit &&
                     command != MenuCommandReturnToMain &&
                     command != MenuCommandReturnToPrevious);

            return command;
        }
    }
}