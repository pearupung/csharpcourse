using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Transactions;
using FourConnectCore.MenuItems;

namespace FourConnectCore
{
    class Program
    {
        private static Menu _menu;
        static void Main(string[] args)
        {
            var menuView = new MenuView();
            menuView.SetStartMenu(new MainMenu());
            var failedAction = MenuAction.Chill;
            do
            {
                Console.Clear();
                Console.WriteLine(failedAction == 0 ? "" : failedAction.ToString());
                failedAction = 0;
                Console.WriteLine(menuView);
                var command = Console.ReadLine()?.Trim().ToUpper() ?? "";
                if (menuView.MenuItems.ContainsKey(command))
                {
                    var menuItem = menuView.MenuItems[command];
                    var action = menuView.PickMenuItem(menuItem);
                    switch (action)
                    {
                        case MenuAction.Exit:
                            menuView.Exit();
                            break;
                        case MenuAction.LeaveMenu:
                            menuView.LeaveMenu();
                            break;
                        case MenuAction.GoToMainMenu:
                            menuView.GoToMainMenu();
                            break;
                        case MenuAction.GoToGameMenu:
                            menuView.GoToMenu(new GameMenu());
                            break;
                        case MenuAction.GoToGamePrepMenu:
                            menuView.GoToMenu(new GamePrepMenu());
                            break;
                        case MenuAction.GoToSettingsMenu:
                            menuView.GoToMenu(new SettingsMenu());
                            break;
                        case MenuAction.GoToLoadGameMenu:
                            menuView.GoToMenu(new LoadGameMenu());
                            break;
                        default:
                            failedAction = action;
                            break;
                    }
                }
            } while (menuView.MenuStackSize > 0);
        }
    }
}