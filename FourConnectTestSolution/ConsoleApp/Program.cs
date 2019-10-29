using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text.Json;
using System.Transactions;
using static FourConnectCore.GameState;

namespace FourConnectCore
{
    class Program
    {
        static List<GameState> _states = new List<GameState>();
        private static GameState _firstTurn = XTurn;
        private static GameState _secondTurn = OTurn;
        private static LoadGameView _loadView = new LoadGameView();

        
        static void Main(string[] args)
        {
            
            newMenuThing();
        }

        public static void newMenuThing()
        {
            var menuFactory = new MenuFactory();
            Func<string, Menu> getMenu = menuFactory.GetMenu;
            var menuView = new MenuView(getMenu("MainMenu"));
            var settings = Settings.GetSettings();
            var game = new GameBoard(4, 4);
            var failedAction = MenuAction.Chill;
            bool paused = true;
            
            string input = "";
            do
            {
                Console.Clear();
                Console.WriteLine(failedAction == 0 ? "" : failedAction.ToString());
                failedAction = 0;

                string graphic = "";
                

                switch (menuView.Menu.Name)
                {
                    case string GameString when GameString.Contains("GameMenu"):
                        graphic = game.ToString();
                        break;
                    case "SettingsMenu":
                        graphic = settings.ToString();
                        break;
                    case "GameSaveMenu":
                        graphic = $"Save the game under the name: {input}";
                        break;
                    case "GameLoadMenu":
                        graphic = _loadView.ToString();
                        break;
                    default:
                        graphic = "";
                        break;
                }
                Console.WriteLine(graphic);
                
                Console.WriteLine(menuView);
                var command = Console.ReadLine()?.Trim().ToUpper() ?? "";
                if (menuView.MenuItems.ContainsKey(command))
                {
                    var menuItem = menuView.MenuItems[command];
                    var action = menuView.PickMenuItem(menuItem);
                    switch (action)
                    {
                        case MenuAction.Exit:
                            paused = true;
                            menuView.Exit();
                            break;
                        case MenuAction.LeaveMenu:
                            if (menuView.Menu.Name.Contains("GameMenu")) paused = true;
                            menuView.LeaveMenu();
                            break;
                        case MenuAction.GoToMainMenu:
                            paused = true;
                            menuView.GoToMainMenu();
                            break;
                        case MenuAction.GoToGameMenu:
                            menuView.GoToMenu("GameMenu");
                            paused = false;
                            break;
                        case MenuAction.GoToGamePrepMenu:
                            menuView.GoToMenu("GamePrepMenu");
                            break;
                        case MenuAction.GoToSettingsMenu:
                            menuView.GoToMenu("SettingsMenu");
                            break;
                        case MenuAction.GoToLoadGameMenu:
                            menuView.GoToMenu("GameLoadMenu");
                            break;
                        case MenuAction.PlayAgainstALocalPlayer:
                            game = new GameBoard(settings.GetBoardHeight(), settings.GetBoardWidth());
                            paused = false;
                            break;
                        case MenuAction.PlayX:
                            if (!All(XTurn))
                            {
                                _firstTurn = XTurn;
                                _secondTurn = OTurn;
                            }
                            game.PutX();
                            menuView.LeaveMenu();
                            break;
                        case MenuAction.PlayO:
                            if (!All(OTurn))
                            {
                                _firstTurn = OTurn;
                                _secondTurn = XTurn;
                            }
                            game.PutO();
                            menuView.LeaveMenu();
                            break;
                        case MenuAction.GoLeftOneColumn:
                            game.MoveLeft();
                            menuView.LeaveMenu();
                            break;
                        case MenuAction.GoRightOneColumn:
                            game.MoveRight();
                            menuView.LeaveMenu();
                            break;
                        case MenuAction.NextSetting:
                            settings.ToggleValueSelected();
                            break;
                        case MenuAction.NextLoadGame:
                            _loadView.NextGame();
                            break;
                        case MenuAction.Decrement:
                            settings.DecreaseValue();
                            break;
                        case MenuAction.Increment:
                            settings.IncreaseValue();
                            break;
                        case MenuAction.SaveTheGame:
                            paused = true;
                            menuView.LeaveMenu();
                            menuView.GoToMenu("GameSaveMenu");
                            break;
                        case MenuAction.Confirm when menuView.Menu.Name.Equals("GameSaveMenu"):
                            _loadView.GameSave(game, input);
                            menuView.LeaveMenu();
                            paused = false;
                            break;
                        case MenuAction.Confirm when menuView.Menu.Name.Equals("GameLoadMenu"):
                            game = _loadView.GetSelectedGameBoard();
                            paused = false;
                            break;
                        default:
                            failedAction = action;
                            break;
                    } 
                    if (paused) continue;
                    _states.Clear();
                    _states = GetGameBoardState(game.ToArray());
                    if (game.SelectedColumn == 0)
                    {
                        _states.Add(LeftMostSelected);
                    }

                    if (game.SelectedColumn == game.Width - 1)
                    {
                        _states.Add(RightMostSelected);
                    }

                    if (All(XTurn, LeftMostSelected))
                    {
                        menuView.GoToMenu("XRightGameMenu");
                    } else if (All(XTurn, RightMostSelected))
                    {
                        menuView.GoToMenu("XLeftGameMenu");
                    } else if (All(OTurn, LeftMostSelected))
                    {
                        menuView.GoToMenu("ORightGameMenu");
                    } else if (All(OTurn, RightMostSelected))
                    {
                        menuView.GoToMenu("OLeftGameMenu");
                    } else if (All(OTurn))
                    {
                        menuView.GoToMenu("OGameMenu");
                    } else if (All(XTurn))
                    {
                        menuView.GoToMenu("XGameMenu");
                    } else if (All(LeftMostSelected))
                    {
                        menuView.GoToMenu("RightGameMenu");
                    } else if (All(RightMostSelected))
                    {menuView.GoToMenu("LeftGameMenu");}
                    else
                    {menuView.GoToMenu("GameMenu");}
                }
                else if (menuView.Menu.Name.Equals("GameSaveMenu"))
                {
                    input = command;
                }

            } while (menuView.MenuStackSize > 0);
            
        }

        public static void testJson()
        {
            var jsonTestMenu = new Menu()
            {
                Title = "Hello World! MenuTitle",
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {"S", new MenuItem()
                        {
                            Title = "MenuItemTitle1",
                            ActionToTake = MenuAction.Chill,
                        }
                    },
                    {
                        "B", new MenuItem()
                        {
                            Title = "MenuItemTitle2",
                            ActionToTake = MenuAction.Confirm
                        }
                    }
                }
            };

            var menuList = new List<Menu>()
            {
                jsonTestMenu, new Menu()
            };

            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                AllowTrailingCommas = true,
            };

            var json = JsonSerializer.Serialize(menuList, options);
            Console.WriteLine(json);
            var postMenuList = JsonSerializer.Deserialize<List<Menu>>(json, options);
            Console.WriteLine(postMenuList);
        }

        public static void SaveToJson<T>(string fileName)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                AllowTrailingCommas = true,
            };
            
        }

        private static bool All(params GameState[] statesToCheck)
        {
            return statesToCheck.All(_states.Contains);
        }

        public static List<GameState> GetGameBoardState(CellType[,] board)
        {
            var xCount = 0;
            var oCount = 0;
            var stateList = new List<GameState>();
            for (int i = 0; i <= board.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= board.GetUpperBound(1); j++)
                {
                    switch (board[i,j])
                    {
                        case CellType.Empty when !stateList.Contains(InProgress):
                            stateList.Add(InProgress);
                            break;
                        case CellType.X:
                            xCount++;
                            break;
                        case CellType.O:
                            oCount++;
                            break;
                    }
                }
            }

            if (xCount == 0 && oCount == 0)
            {
                stateList.Add(FirstMove);
            } else if (xCount == oCount)
            {
                stateList.Add(_firstTurn);
            }
            else
            {
                stateList.Add(_secondTurn);
            }
            
            return stateList;
        }
    }
}