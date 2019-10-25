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

        private static string TestGame()
        {
            var settings = Settings.GetSettings();
            var board = new GameBoard(settings.GetBoardHeight(), settings.GetBoardWidth(), EndGameIfBoardIsFull);
            var putXMenuItem = new MenuItem()
            {
                Title = "Put X to selected column",
                CommandToExecute = board.PutX
            };
            var putOMenuItem = new MenuItem()
            {
                Title = "Put O to selected column",
                CommandToExecute = board.PutO
            };
            var gameMenu = new Menu(2)
            {
                TogglableMenuItems = new Dictionary<MenuItem, List<MenuItem>>()
                {
                    {
                        putXMenuItem, new List<MenuItem>()
                        {
                            putOMenuItem
                        }
                    },
                    {
                        putOMenuItem, new List<MenuItem>()
                        {
                            putXMenuItem
                        }
                    }
                },
                GetGraphic = board.ToString,
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "A", new MenuItem()
                        {
                            Title = "Move left",
                            CommandToExecute = board.MoveLeft,
                        }
                    },
                    {
                        "D", new MenuItem()
                        {
                            Title = "Move right",
                            CommandToExecute = board.MoveRight,
                        }
                    },
                    {
                        "X", putXMenuItem
                    },
                    {
                        "O", putOMenuItem
                    },

                }
                
                
            };
            return gameMenu.Run();
        }

        public static GameState EndGameIfBoardIsFull(CellType[,] board)
        {
            for (int i = 0; i <= board.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= board.GetUpperBound(1); j++)
                {
                    if (board[i,j] == CellType.Empty)
                    {
                        return GameState.InProgress;
                    }
                }
            }
            return GameState.Tie;
        }
        
        
    }
}