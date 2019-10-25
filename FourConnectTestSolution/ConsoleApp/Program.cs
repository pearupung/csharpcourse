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
            var game = new GameBoard(4,4, EndGameIfBoardIsFull);
            var failedAction = MenuAction.Chill;
            do
            {
                Console.Clear();
                Console.WriteLine(failedAction == 0 ? "" : failedAction.ToString());
                failedAction = 0;
                if (menuView.Menu is GameMenu)
                {
                    Console.WriteLine(game);
                }
                
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
                        case MenuAction.PlayAgainstALocalPlayer:
                            menuView.GoToMenu(new GameMenu());
                            break;
                        case MenuAction.PlayX:
                            game.PutX();
                            break;
                        case MenuAction.PlayO:
                            game.PutO();
                            break;
                        case MenuAction.GoLeftOneColumn:
                            game.MoveLeft();
                            break;
                        case MenuAction.GoRightOneColumn:
                            game.MoveRight();
                            break;
                        default:
                            failedAction = action;
                            break;
                    }
                }
            } while (menuView.MenuStackSize > 0);
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