using System;
using System.Collections.Generic;
using System.Linq;
using static FourConnectCore.GameState;


namespace FourConnectCore
{
    public class ConsoleApp
    {
        private GameBoard _board;
        private List<GameState> _gameStates;
        private MenuView _menuView;
        private LoadGameView _loadView;
        private Settings _settings;
        private bool _isPaused = true;
        private string input;
        private string previous_input;

        private Func<string,MenuAction> _getAction;
        private Func<string> _getInput;
        private Action<MenuView> _showMenu;
        private Action<LoadGameView> _showSavedGames;
        private Action<GameBoard> _showGameBoard;
        private Action<Settings> _showSettings;
        private Action<string> _showUserInput;
        private readonly List<Func<GameBoard, List<GameState>>> _gameStateProviders = 
            new List<Func<GameBoard, List<GameState>>>();

        public void RunApp()
        {
            // Set up game state providers
            _gameStateProviders.Add(CursorStateProvider);
            _gameStateProviders.Add(PlayerMoveProvider);
            _gameStateProviders.Add(EndStateProvider);
            
            // Set up local variables
            _menuView = new MenuView();
            _loadView = new LoadGameView();
            _settings = Settings.GetSettings();
            _gameStates = new List<GameState>();
            
            // Set up user interaction functions
            _getInput = () =>
            {
                Console.Write(">");
                return Console.ReadLine();
            };
            _getAction = (key) =>
            {
                var items = _menuView.Menu.MenuItemsDictionary;
                return items.ContainsKey(key) ? items[key].ActionToTake : MenuAction.Chill;
            };

            // Set up user interface functions
            _showGameBoard = Console.WriteLine;
            _showMenu = Console.WriteLine;
            _showSavedGames = Console.WriteLine;
            _showSettings = Console.WriteLine;
            _showUserInput = Console.WriteLine;
            

            do
            {
                // Show app state
                // Maybe convert to having enum as a menu identifier?
                
                switch (_menuView.Menu.Name)
                {
                    case { } gameString when gameString.Contains("GameMenu"):
                        _showGameBoard(_board);
                        break;
                    case "SettingsMenu":
                        _showSettings(_settings);
                        break;
                    case "GameSaveMenu":
                        _showUserInput(input);
                        break;
                    case "GameLoadMenu":
                        _showSavedGames(_loadView);
                        break;
                }
                _showMenu(_menuView);
                
                // Ask for input
                input = _getInput();
                var action = _getAction(input);
                Console.Clear();
                if (action != MenuAction.Chill)
                {
                    // Change state due to input
                    ApplyAppStateChanges(action);

                    if (!_isPaused)
                    {
                        _gameStates.Clear();
                        ApplyCurrentGameState();
                        ApplyNextGameMenu();
                    }
                }

                previous_input = input;

            } while (_menuView.MenuStackSize > 0);
        }

        private List<GameState> EndStateProvider(GameBoard board)
        {
            return new List<GameState>();
        }

        private List<GameState> PlayerMoveProvider(GameBoard gameBoard)
        {
            var xCount = 0;
            var oCount = 0;
            var board = gameBoard.ToArray();
            var stateList = new List<GameState>();
            
            GameState[] firstMove = gameBoard.FirstMove == CellType.X ? new GameState[]{XTurn, OTurn} : new GameState[]
            {
                OTurn, XTurn
            };
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
                stateList.Add(firstMove[0]);
            }
            else
            {
                stateList.Add(firstMove[1]);
            }
            
            return stateList;
        }

        private List<GameState> CursorStateProvider(GameBoard board)
        {
            var list = new List<GameState>();
            if (board.SelectedColumn == 0)
            {
                list.Add(LeftMostSelected);
            }

            if (board.SelectedColumn == board.Width - 1)
            {
                list.Add(RightMostSelected);
            }

            return list;
        }

        private void ApplyCurrentGameState()
        {
            foreach (var gameStateProvider in _gameStateProviders)
            {
                _gameStates.AddRange(gameStateProvider(_board));
            }
        }

        private void ApplyAppStateChanges(MenuAction action)
        {
            switch (action)
            {
                case MenuAction.Exit:
                    _isPaused = true;
                    _menuView.Exit();
                    break;
                case MenuAction.LeaveMenu:
                    if (_menuView.Menu.Name.Contains("GameMenu")) _isPaused = true;
                    _menuView.LeaveMenu();
                    break;
                case MenuAction.GoToMainMenu:
                    _isPaused = true;
                    _menuView.GoToMainMenu();
                    break;
                case MenuAction.GoToGameMenu:
                    _menuView.GoToMenu("GameMenu");
                    _isPaused = false;
                    break;
                case MenuAction.GoToGamePrepMenu:
                    _menuView.GoToMenu("GamePrepMenu");
                    break;
                case MenuAction.GoToSettingsMenu:
                    _menuView.GoToMenu("SettingsMenu");
                    break;
                case MenuAction.GoToLoadGameMenu:
                    _menuView.GoToMenu("GameLoadMenu");
                    break;
                case MenuAction.PlayAgainstALocalPlayer:
                    _board = new GameBoard(_settings.GetBoardHeight(), _settings.GetBoardWidth());
                    _isPaused = false;
                    break;
                case MenuAction.PlayX:
                    _board.PutX();
                    _menuView.LeaveMenu();
                    break;
                case MenuAction.PlayO:
                    _board.PutO();
                    _menuView.LeaveMenu();
                    break;
                case MenuAction.GoLeftOneColumn:
                    _board.MoveLeft();
                    _menuView.LeaveMenu();
                    break;
                case MenuAction.GoRightOneColumn:
                    _board.MoveRight();
                    _menuView.LeaveMenu();
                    break;
                case MenuAction.NextSetting:
                    _settings.ToggleValueSelected();
                    break;
                case MenuAction.NextLoadGame:
                    _loadView.NextGame();
                    break;
                case MenuAction.Decrement:
                    _settings.DecreaseValue();
                    break;
                case MenuAction.Increment:
                    _settings.IncreaseValue();
                    break;
                case MenuAction.SaveTheGame:
                    _isPaused = true;
                    _menuView.LeaveMenu();
                    _menuView.GoToMenu("GameSaveMenu");
                    break;
                case MenuAction.Confirm when _menuView.IsMenu("GameSaveMenu"):
                    _loadView.GameSave(_board, previous_input);
                    _menuView.LeaveMenu();
                    _isPaused = false;
                    break;
                case MenuAction.Confirm when _menuView.IsMenu("GameLoadMenu"):
                    _board = _loadView.GetSelectedGameBoard();
                    _isPaused = false;
                    break;
                default:
                    Console.WriteLine($"Action {action} fell through!");
                    break;
            }
        }

        private void ApplyNextGameMenu()
        {
            if (All(XTurn, LeftMostSelected))
            {
                _menuView.GoToMenu("XRightGameMenu");
            }
            else if (All(XTurn, RightMostSelected))
            {
                _menuView.GoToMenu("XLeftGameMenu");
            }
            else if (All(OTurn, LeftMostSelected))
            {
                _menuView.GoToMenu("ORightGameMenu");
            }
            else if (All(OTurn, RightMostSelected))
            {
                _menuView.GoToMenu("OLeftGameMenu");
            }
            else if (All(OTurn))
            {
                _menuView.GoToMenu("OGameMenu");
            }
            else if (All(XTurn))
            {
                _menuView.GoToMenu("XGameMenu");
            }
            else if (All(LeftMostSelected))
            {
                _menuView.GoToMenu("RightGameMenu");
            }
            else if (All(RightMostSelected))
            {
                _menuView.GoToMenu("LeftGameMenu");
            } else if (All(Tie))
            {
                //_menuView.GoToMenu("");
            }
            else
            {
                _menuView.GoToMenu("GameMenu");
            }
        }

        private bool All(params GameState[] statesToCheck)
        {
            return statesToCheck.All(_gameStates.Contains);
        }
    }
}