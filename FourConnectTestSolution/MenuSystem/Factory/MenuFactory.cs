using System;
using System.Collections.Generic;
using System.Linq;

namespace MenuSystem.Factory
{
    public class MenuFactory
    {
        private readonly MenuItemFactory _itemFactory = new MenuItemFactory();
        public readonly List<Menu> _menus;

        public Menu GetMenu(string name)
        {
            foreach (var menu in _menus)
            {
                if (menu.Name.Equals(name))
                {
                    return new Menu()
                    {
                        Name = menu.Name,
                        Title = menu.Title,
                        MenuItemsDictionary = menu.MenuItemsDictionary
                            .ToDictionary(pair => pair.Key,pair => pair.Value)
                    };
                }
            }
            throw new Exception($"Menu {name} not found in factory.");
        }
        
        

        public MenuFactory()
        {
            Func<string, MenuItem> getItem = _itemFactory.GetMenuItem;
            _menus = new List<Menu>()
            {
                new Menu()
                {
                    Name = "MainMenu",
                    Title = "Main Menu",
                    MenuItemsDictionary = new Dictionary<string, MenuItem>()
                    {
                        {"1", getItem("GoToGamePrepMenu")},
                        {"2", getItem("GoToLoadGameMenu")},
                        {"3", getItem("GoToSettingsMenu")},
                    }
                },
                new Menu()
                {
                    Name = "SettingsMenu",
                    Title = "Settings",
                    MenuItemsDictionary = new Dictionary<string, MenuItem>()
                    {
                        {"1", getItem("Decrement")},
                        {"2", getItem("Increment")},
                        {"3", getItem("NextSetting")}
                    }
                },
                new Menu()
                {
                    Name = "GamePrepMenu",
                    Title = "Choose game mode",
                    MenuItemsDictionary = new Dictionary<string, MenuItem>()
                    {
                        {"1", getItem("PlayAgainstTheMachine")},
                        {"2", getItem("PlayAgainstALocalPlayer")}
                    }
                },
                new Menu()
                {
                    Name = "GameLoadMenu",
                    Title = "Load Game",
                    MenuItemsDictionary = new Dictionary<string, MenuItem>()
                    {
                        {"1", getItem("Confirm")},
                        {"2", getItem("NextLoadGame")}
                    }
                },
                new Menu()
                {
                    Name = "GameMenu",
                    Title = "Pick a side!",
                    MenuItemsDictionary = new Dictionary<string, MenuItem>()
                    {
                        {"1", getItem("PlayX")},
                        {"2", getItem("PlayO")},
                        {"3", getItem("GoLeftOneColumn")},
                        {"4", getItem("GoRightOneColumn")},
                        {"5", getItem("SaveTheGame")}
                    }
                },
                // 7
                
                new Menu()
                {
                    Name = "LeftGameMenu",
                    Title = "Pick a side!",
                    MenuItemsDictionary = new Dictionary<string, MenuItem>()
                    {
                        {"1", getItem("PlayX")},
                        {"2", getItem("PlayO")},
                        {"3", getItem("GoLeftOneColumn")},
                        {"5", getItem("SaveTheGame")}
                    }
                },
                // 8
                new Menu()
                {
                    Name = "RightGameMenu",
                    Title = "Pick a side!",
                    MenuItemsDictionary = new Dictionary<string, MenuItem>()
                    {
                        {"1", getItem("PlayX")},
                        {"2", getItem("PlayO")},
                        {"4", getItem("GoRightOneColumn")},
                        {"5", getItem("SaveTheGame")}
                    }
                },
                
                // 9
                new Menu()
                {
                    Name = "XGameMenu",
                    Title = "Player X, do your best!",
                    MenuItemsDictionary = new Dictionary<string, MenuItem>()
                    {
                        {"1", getItem("PlayX")},
                        {"3", getItem("GoLeftOneColumn")},
                        {"4", getItem("GoRightOneColumn")},
                        {"5", getItem("SaveTheGame")}
                    }
                },
                // 10
                new Menu()
                {
                    Name = "OGameMenu",
                    Title = "Player O, wish you luck!",
                    MenuItemsDictionary = new Dictionary<string, MenuItem>()
                    {
                        {"2", getItem("PlayO")},
                        {"3", getItem("GoLeftOneColumn")},
                        {"4", getItem("GoRightOneColumn")},
                        {"5", getItem("SaveTheGame")}
                    }
                },
                // 11
                new Menu()
                {
                    Name = "XLeftGameMenu",
                    Title = "Player X, do your best!",
                    MenuItemsDictionary = new Dictionary<string, MenuItem>()
                    {
                        {"1", getItem("PlayX")},
                        {"3", getItem("GoLeftOneColumn")},
                        {"5", getItem("SaveTheGame")}
                    }
                },
                // 12
                new Menu()
                {
                    Name = "XRightGameMenu",
                    Title = "Player X, do your best!",
                    MenuItemsDictionary = new Dictionary<string, MenuItem>()
                    {
                        {"1", getItem("PlayX")},
                        {"4", getItem("GoRightOneColumn")},
                        {"5", getItem("SaveTheGame")}
                    }

                },
                // 13
                new Menu()
                {
                    Name = "OLeftGameMenu",
                    Title = "Player O, wish you luck!",
                    MenuItemsDictionary = new Dictionary<string, MenuItem>()
                    {
                        {"2", getItem("PlayO")},
                        {"3", getItem("GoLeftOneColumn")},
                        {"5", getItem("SaveTheGame")}
                    }

                },
                // 14
                new Menu()
                {
                    Name = "ORightGameMenu",
                    Title = "Player O, wish you luck!",
                    MenuItemsDictionary = new Dictionary<string, MenuItem>()
                    {
                        {"2", getItem("PlayO")},
                        {"4", getItem("GoRightOneColumn")},
                        {"5", getItem("SaveTheGame")}
                    }

                },
                // 15
                new Menu()
                {
                    Name = "GameSaveMenu",
                    Title = "Save the game!",
                    MenuItemsDictionary = new Dictionary<string, MenuItem>()
                    {
                        {"?", getItem("Input")},
                        {"1", getItem("Confirm")},
                        {"2", getItem("Cancel")}
                    }
                },
                // 16
                new Menu()
                {
                    Name = "GameEndMenu",
                    Title = "Game over!",
                    MenuItemsDictionary = new Dictionary<string, MenuItem>()
                    {
                        {"1", getItem("NewGame")}
                    }
                }
                
               
            };
        }
        
        
    }
    
    
    
}