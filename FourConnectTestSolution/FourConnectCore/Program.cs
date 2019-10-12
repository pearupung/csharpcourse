﻿using System;
using System.Collections.Generic;
using System.Transactions;

namespace FourConnectCore
{
    class Program
    {
        static void Main(string[] args)
        {

            RunMenu();

        }

        private static string RunMenu()
        {
            Console.Clear();
            
            Console.WriteLine($"Hello to FourConnect!");

            var menuLevel2 = new Menu(2)
            {
                Title = "Level2 menu",
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {"1", new MenuItem() 
                        {
                            Title = "Nothing here",
                            CommandToExecute = null
                        }
                    }
                }
            };

            var gameMenu = new Menu(1)
            {
                Title = $"Start a new game of FourConnect!",
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "1", new MenuItem()
                        {
                            Title = "Computer starts",
                            CommandToExecute = TestGame
                        }
                    },
                    {
                        "A", new MenuItem()
                        {
                            Title = "Alien starts",
                            CommandToExecute = null
                        }
                    },
                    {
                        "2", new MenuItem()
                        {
                            Title = "Human starts",
                            CommandToExecute = null
                        }
                    },
                    {
                        "4", new MenuItem()
                        {
                            Title = "level2 menu",
                            CommandToExecute = menuLevel2.Run
                        }
                    }
                }
            };
            
            var menu0 = new Menu(0)
            {
                Title = $"Game main menu",
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "S", new MenuItem()
                        {
                            Title = "Start game",
                            CommandToExecute = gameMenu.Run
                        }
                    },
                    {
                        "J", new MenuItem()
                        {
                            Title =  "Set defaults for game",
                            CommandToExecute = null
                        }
                    }
                }
            };

            return menu0.Run();
        }

        private static string TestGame()
        {
            var board = new GameBoard(4, 4, EndGameIfBoardIsFull);
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