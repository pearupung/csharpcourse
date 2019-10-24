using System;
using System.Collections.Generic;
using System.Linq;

namespace FourConnectCore
{
    public class Menu
    {
        private readonly int _menuLevel;

        public Func<string> GetGraphic { get; set; }
        private const string MenuCommandExit = "E";
        private const string MenuCommandReturnToPrevious = "P";
        private const string MenuCommandReturnToMain = "M";

        private readonly Dictionary<string, MenuItem> _defaultMenuItemsDictionary = new Dictionary<string, MenuItem>()
        {
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
            }
        };


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
                .ToDictionary(p => p.Key, p => p.Value)
                .Where(pair => pair.Value.IsVisible(_menuLevel))
                .ToDictionary(pair => pair.Key, pair => pair.Value);
            set => _menuItemsDictionary = value;
        }

        public Func<string> PickMenuItem(string str)
        {
            var menuItem = MenuItemsDictionary[str];

            if (!menuItem.IsExecutable(_menuLevel)) return null;

            var commandToExecute = MenuItemsDictionary[str].CommandToExecute;

            if (!TogglableMenuItems.ContainsKey(menuItem)) return commandToExecute;

            ToggleMenuItems(menuItem);

            return commandToExecute;
        }

        public Func<string, bool> ExitMenu = command => command != MenuCommandExit &&
                                                        command != MenuCommandReturnToMain &&
                                                        command != MenuCommandReturnToPrevious;

        private void ToggleMenuItems(MenuItem menuItem)
        {
            foreach (var item in TogglableMenuItems[menuItem])
            {
                item.IsHidden = false;
            }
            menuItem.IsHidden = true;
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

                foreach (var (comm, menuItem) in MenuItemsDictionary)
                {
                    Console.Write(comm);
                        Console.Write(" ");
                        Console.WriteLine(menuItem);
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
                        returnCommand = PickMenuItem(command)();
                        
                    }
                }

                if (returnCommand == MenuCommandExit ||
                    returnCommand == MenuCommandReturnToMain && _menuLevel != 0) return returnCommand;
            } while (ExitMenu(command));

            return "";
        }
    }
}