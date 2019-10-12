using System;
using System.Collections.Generic;

namespace FourConnectCore
{
    public class Menu
    {
        private int _menuLevel;

        public Func<string> GetGraphic { get; set; }
        private const string MenuCommandExit = "E";
        private const string MenuCommandReturnToPrevious = "P";
        private const string MenuCommandReturnToMain = "M";
        

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
            get => _menuItemsDictionary;
            set
            {
                _menuItemsDictionary = value;
                if (_menuLevel >= 2)
                {
                    _menuItemsDictionary.Add(MenuCommandReturnToPrevious,
                        new MenuItem(){Title = "Return to Previous Menu"});
                }
                if (_menuLevel >= 1)
                {
                    _menuItemsDictionary.Add(MenuCommandReturnToMain,
                        new MenuItem(){Title = "Return to Main Menu"});
                }
                _menuItemsDictionary.Add(MenuCommandExit,
                    new MenuItem(){Title = "Exit"});
                
            }
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

                    if (!menuItem.Value.IsHidden)
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
                    if (menuItem.CommandToExecute != null && !menuItem.IsHidden)
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

                if (returnCommand == MenuCommandExit)
                {
                    command = MenuCommandExit;
                }

                if (returnCommand == MenuCommandReturnToMain)
                {
                    if (_menuLevel != 0)
                    {
                        command = MenuCommandReturnToMain;
                    }
                }

            } while (command != MenuCommandExit && 
                     command != MenuCommandReturnToMain &&     
                     command != MenuCommandReturnToPrevious);

            return command;
        }
    }
}