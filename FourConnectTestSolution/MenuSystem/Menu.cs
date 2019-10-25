using System;
using System.Collections.Generic;
using System.Linq;
using FourConnectCore.MenuItems;

namespace FourConnectCore
{
    public class Menu
    {
        public int MenuLevel { get; set;}

        public Func<string> GetGraphic { get; set; }
        private const string MenuCommandExit = "E";
        private const string MenuCommandReturnToPrevious = "P";
        private const string MenuCommandReturnToMain = "M";

        private readonly Dictionary<string, MenuItem> _defaultMenuItemsDictionary = new Dictionary<string, MenuItem>()
        {
            {
                MenuCommandReturnToPrevious,
                new LeaveMenu()
            },
            {
                MenuCommandReturnToMain,
                new GoToMainMenu()
            },
            {
                MenuCommandExit,
                new Exit()
            }
        };


        private Dictionary<string, MenuItem> _menuItemsDictionary = new Dictionary<string, MenuItem>();

        public Dictionary<MenuItem, List<MenuItem>> TogglableMenuItems { get; set; } =
            new Dictionary<MenuItem, List<MenuItem>>();


        public Menu(int menuLevel = 0)
        {
            MenuLevel = menuLevel;
        }
        public string Title { get; set; }

        public Dictionary<string, MenuItem> MenuItemsDictionary
        {
            get => _menuItemsDictionary.Concat(_defaultMenuItemsDictionary)
                .ToDictionary(p => p.Key, p => p.Value)
                .Where(pair => pair.Value.IsVisible(MenuLevel))
                .ToDictionary(pair => pair.Key, pair => pair.Value);
            set => _menuItemsDictionary = value;
        }

        public Func<string> PickMenuItem(string str)
        {
            var menuItem = MenuItemsDictionary[str];

            if (!menuItem.IsExecutable(MenuLevel)) return null;

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
                    if (menuItem.IsExecutable(MenuLevel))
                    {
                        returnCommand = PickMenuItem(command)();
                        
                    }
                }

                if (returnCommand == MenuCommandExit ||
                    returnCommand == MenuCommandReturnToMain && MenuLevel != 0) return returnCommand;
            } while (ExitMenu(command));

            return "";
        }
    }
}