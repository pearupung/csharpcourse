using System;
using System.Collections.Generic;

namespace FourConnectCore
{
    public class MenuItemFactory
    {
        public MenuItem GetMenuItem(string name)
        {
            foreach (var menuItem in _menuItems)
            {
                if (menuItem.Name.Equals(name))
                {
                    return new MenuItem()
                    {
                        Name = menuItem.Name,
                        Title = menuItem.Title,
                        ActionToTake = menuItem.ActionToTake
                    };
                }
            }
            
            throw new Exception($"MenuItem {name} not found in MenuItemFactory.");
        }



        private List<MenuItem> _menuItems = new List<MenuItem>()
        {
            // Gameplay MenuItems
            
            new MenuItem()
            {
                Name = "GoLeftOneColumn",
                Title = "Go left one column",
                ActionToTake = MenuAction.GoLeftOneColumn
            },
            new MenuItem()
            {
                Name = "GoRightOneColumn",
                Title = "Go right one column",
                ActionToTake = MenuAction.GoRightOneColumn
            },
            new MenuItem()
            {
                Name = "PlayO",
                Title = "Place O in the selected column",
                ActionToTake = MenuAction.PlayO
            },
            new MenuItem()
            {
                Name = "PlayX",
                Title = "Place X in the selected column",
                ActionToTake = MenuAction.PlayX
            },
            new MenuItem()
            {
                Name = "SaveGame",
                Title = "Save",
                ActionToTake = MenuAction.SaveTheGame
            },
            
            // GamePrepMenu MenuItems
            
            new MenuItem()
            {
                Name = "AgainstComputer",
                Title = "Play against the machine",
                ActionToTake = MenuAction.PlayAgainstTheMachine
            },
            new MenuItem()
            {
                Name = "LocalMultiPlayer",
                Title = "Initiate gameplay against a local foe",
                ActionToTake = MenuAction.PlayAgainstALocalPlayer
            },
            
            // MainMenu MenuItems
            
            new MenuItem()
            {
                Name = "LoadGame",
                Title = "Load game",
                ActionToTake = 0
            },
            new MenuItem()
            {
                Name = "Play",
                Title = "Play",
                ActionToTake = MenuAction.GoToGamePrepMenu
            },
            new MenuItem()
            {
                Name = "GoToSettingsMenu",
                Title = "Settings",
                ActionToTake = MenuAction.GoToSettingsMenu
            },
            
            // MenuChange MenuItems
            
            new MenuItem()
            {
                Name = "ExitProgram",
                Title = "Exit",
                ActionToTake = MenuAction.Exit
            },
            new MenuItem()
            {
                Name = "GoToGamePrepMenu",
                Title = "Play",
                ActionToTake = MenuAction.GoToGamePrepMenu
            },
            new MenuItem()
            {
                Name = "GoToMainMenu",
                Title = "Back to main menu",
                ActionToTake = MenuAction.GoToMainMenu
            },
            new MenuItem()
            {
                Name = "LeaveMenu",
                Title = "Back",
                ActionToTake = MenuAction.LeaveMenu
            },
            new MenuItem()
            {
                Name = "GoToLoadGameMenu",
                Title = "Load Game",
                ActionToTake = MenuAction.GoToLoadGameMenu
            },
            
            // Settings menu
            
            new MenuItem()
            {
                Name = "DecrementValue",
                Title = "Decrement",
                ActionToTake = MenuAction.Decrement
            },
            new MenuItem()
            {
                Name = "IncrementValue",
                Title = "Increment",
                ActionToTake = MenuAction.Increment
            },
            new MenuItem()
            {
                Name = "ToggleValue",
                Title = "Toggle value selected",
                ActionToTake = MenuAction.NextSetting
            },
            
            // Prompt MenuItems
            
            new MenuItem()
            {
                Name = "Cancel",
                Title = "Cancel",
                ActionToTake = MenuAction.Cancel
            },
            new MenuItem()
            {
                Name = "Confirm",
                Title = "Confirm",
                ActionToTake = MenuAction.Confirm
            },
            new MenuItem()
            {
                Name = "Input",
                Title = "Write anything and press enter!",
                ActionToTake = MenuAction.Input
            },
            new MenuItem()
            {
                Name = "NextLoadGame",
                Title = "Select the next game",
                ActionToTake = MenuAction.NextLoadGame
            }

        };

    }
    
}