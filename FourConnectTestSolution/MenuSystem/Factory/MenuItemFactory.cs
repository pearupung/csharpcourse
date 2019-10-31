using System;
using System.Collections.Generic;
using FourConnectCore;
using FourConnectCore.Domain;

namespace MenuSystem.Factory
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
        
        public static List<MenuItem> _menuItems = new List<MenuItem>()
        {
            // Gameplay MenuItems
            
            new MenuItem()
            {
                Name = "GoLeftOneColumn",
                Title = "Go left one column",
                ActionToTake = AppAction.GoLeftOneColumn
            },
            new MenuItem()
            {
                Name = "GoRightOneColumn",
                Title = "Go right one column",
                ActionToTake = AppAction.GoRightOneColumn
            },
            new MenuItem()
            {
                Name = "PlayO",
                Title = "Place O in the selected column",
                ActionToTake = AppAction.PlayO
            },
            new MenuItem()
            {
                Name = "PlayX",
                Title = "Place X in the selected column",
                ActionToTake = AppAction.PlayX
            },
            new MenuItem()
            {
                Name = "SaveTheGame",
                Title = "Save",
                ActionToTake = AppAction.SaveTheGame
            },
            
            // GamePrepMenu MenuItems
            
            new MenuItem()
            {
                Name = "PlayAgainstTheMachine",
                Title = "Play against the machine",
                ActionToTake = AppAction.PlayAgainstTheMachine
            },
            new MenuItem()
            {
                Name = "PlayAgainstALocalPlayer",
                Title = "Initiate gameplay against a local foe",
                ActionToTake = AppAction.PlayAgainstALocalPlayer
            },
            
            // MainMenu MenuItems
            
            new MenuItem()
            {
                Name = "GoToGamePrepMenu",
                Title = "Play",
                ActionToTake = AppAction.GoToGamePrepMenu
            },
            new MenuItem()
            {
                Name = "GoToSettingsMenu",
                Title = "Settings",
                ActionToTake = AppAction.GoToSettingsMenu
            },
            
            // MenuChange MenuItems
            
            new MenuItem()
            {
                Name = "Exit",
                Title = "Exit",
                ActionToTake = AppAction.Exit
            },
            new MenuItem()
            {
                Name = "GoToGamePrepMenu",
                Title = "Play",
                ActionToTake = AppAction.GoToGamePrepMenu
            },
            new MenuItem()
            {
                Name = "GoToMainMenu",
                Title = "Back to main menu",
                ActionToTake = AppAction.GoToMainMenu
            },
            new MenuItem()
            {
                Name = "LeaveMenu",
                Title = "Back",
                ActionToTake = AppAction.LeaveMenu
            },
            new MenuItem()
            {
                Name = "GoToLoadGameMenu",
                Title = "Load Game",
                ActionToTake = AppAction.GoToLoadGameMenu
            },
            
            // Settings menu
            
            new MenuItem()
            {
                Name = "Decrement",
                Title = "Decrement",
                ActionToTake = AppAction.Decrement
            },
            new MenuItem()
            {
                Name = "Increment",
                Title = "Increment",
                ActionToTake = AppAction.Increment
            },
            new MenuItem()
            {
                Name = "NextSetting",
                Title = "Toggle value selected",
                ActionToTake = AppAction.NextSetting
            },
            
            // Prompt MenuItems
            
            new MenuItem()
            {
                Name = "Cancel",
                Title = "Cancel",
                ActionToTake = AppAction.Cancel
            },
            new MenuItem()
            {
                Name = "Confirm",
                Title = "Confirm",
                ActionToTake = AppAction.Confirm
            },
            new MenuItem()
            {
                Name = "Input",
                Title = "Write anything and press enter!",
                ActionToTake = AppAction.Input
            },
            new MenuItem()
            {
                Name = "NextLoadGame",
                Title = "Select the next game",
                ActionToTake = AppAction.NextLoadGame
            },
            new MenuItem()
            {
                Name = "NewGame",
                Title = "New Game",
                ActionToTake = AppAction.GoToGamePrepMenu
            }

        };

    }
    
}