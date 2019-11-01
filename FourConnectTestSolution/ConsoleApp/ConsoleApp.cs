using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Game;
using MenuSystem;
using static Game.GameState;


namespace FourConnectCore
{
    public class ConsoleApp
    {
        private GameBoard _board;
        private List<GameState> _gameStates;
        private MenuView _menuView;
        private LoadGameView _loadView;
        private Settings _settings;
        private GameEndView _endView;
        private bool _isPaused = true;
        private string input;
        private string previous_input;

        private Func<string,AppAction> _getAction;
        private Func<string> _getInput;
        private Action<MenuView> _showMenu;
        private Action<LoadGameView> _showSavedGames;
        private Action<GameBoard> _showGameBoard;
        private Action<Settings> _showSettings;
        private Action<string> _showUserInput;
        private readonly List<Func<GameBoard, List<GameState>>> _gameStateProviders = 
            new List<Func<GameBoard, List<GameState>>>();

        private Action<GameEndView> _showGameEndView;

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
            _endView = new GameEndView();
            
            // Set up user interaction functions
            _getInput = () =>
            {
                Console.Write(">");
                return Console.ReadLine();
            };

            _getAction = (key) =>
            {
                if (Int32.TryParse(key, out int result))
                {
                    return _menuView.MenuItems[result].AppActionToTake;
                }

                return AppAction.Chill;
            };


            // Set up user interface functions
            _showGameBoard = Console.WriteLine;
            _showMenu = Console.WriteLine;
            _showSavedGames = Console.WriteLine;
            _showSettings = Console.WriteLine;
            _showUserInput = Console.WriteLine;
            _showGameEndView = Console.WriteLine;
            

            do
            {
                // Show app state
                // Maybe convert to having enum as a menu identifier?
                
                switch (_menuView.MenuType)
                {
                    case { } gameString when gameString.ToString().Contains("GameMenu"):
                        _showGameBoard(_board);
                        break;
                    case MenuType.SettingsMenu:
                        _showSettings(_settings);
                        break;
                    case MenuType.GameSaveMenu:
                        _showUserInput(input);
                        break;
                    case MenuType.GameLoadMenu:
                        _showSavedGames(_loadView);
                        break;
                    case MenuType.GameEndMenu:
                        _showGameBoard(_board);
                        _showGameEndView(_endView);
                        break;
                        
                }
                _showMenu(_menuView);
                
                // Ask for input
                input = _getInput();
                var action = _getAction(input);
                Console.Clear();
                if (action != AppAction.Chill)
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
           var list = new List<GameState>();
           var hasOWon = HasFourConnected(board, CellType.O);
           var hasXWon = HasFourConnected(board, CellType.X);
           
           if (hasOWon) list.Add(OWon);
           if (hasXWon) list.Add(XWon);
           return list;
        }
        
        private static bool HasFourConnected(GameBoard board, CellType cellType)
        {
            var array = board.ToArray();
            
            var findDirections = new (int row, int col)[]
            {
                (-1,-1), (-1, 0), (-1, 1),
                (0, -1), (0, 1),
                (1, -1), (1, 0), (1, 1)
            };
            
            for (var row = 0; row < array.GetLength(0); row++)
            for (var col = 0; col < array.GetLength(1); col++)
            {
                var cell = array[row, col];
                var coords = (row, col);
                if (cell != cellType) continue;
                foreach (var findDirection in findDirections)
                {
                    
                    var hasFour = HasFourConnected(1, board, coords, cellType, findDirection);
                    if (hasFour) return true;
                }
            }

            return false;
        }
        
        private static bool HasFourConnected(int connectedCount, 
            GameBoard board, 
            (int row, int col) coords, 
            CellType cellType, 
            (int row, int col) searchDirection)
        {
            
            if (connectedCount == 4 || connectedCount > 4)
            {
                return true;
            }
            var (row, col) = coords;
            var (rowMask, colMask) = searchDirection;
            var newCoords = (row + rowMask, col + colMask);

            if (board.InBounds(newCoords))
            {
                if (board.GetCellType(newCoords) == cellType)
                {
                    return HasFourConnected(connectedCount+1, board, newCoords, cellType, searchDirection);
                }
            }
            
            return false;
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

        private void ApplyAppStateChanges(AppAction action)
        {
            switch (action)
            {
                case AppAction.Exit:
                    _isPaused = true;
                    _menuView.Exit();
                    break;
                case AppAction.LeaveMenu:
                    if (_menuView.MenuType.ToString().Contains("GameMenu")) _isPaused = true;
                    _menuView.LeaveMenu();
                    break;
                case AppAction.GoToMainMenu:
                    _isPaused = true;
                    _menuView.GoToMainMenu();
                    break;
                case AppAction.GoToGameMenu:
                    _menuView.GoToMenu(MenuType.GameMenu);
                    _isPaused = false;
                    break;
                case AppAction.GoToGamePrepMenu:
                    _menuView.GoToMainMenu();
                    _menuView.GoToMenu(MenuType.GamePrepMenu);
                    break;
                case AppAction.GoToSettingsMenu:
                    _menuView.GoToMenu(MenuType.SettingsMenu);
                    break;
                case AppAction.GoToLoadGameMenu:
                    _menuView.GoToMenu(MenuType.GameLoadMenu);
                    break;
                case AppAction.PlayAgainstALocalPlayer:
                    _board = new GameBoard(_settings.GetBoardHeight(), _settings.GetBoardWidth());
                    _isPaused = false;
                    break;
                case AppAction.PlayX:
                    _board.PutX();
                    _menuView.LeaveMenu();
                    break;
                case AppAction.PlayO:
                    _board.PutO();
                    _menuView.LeaveMenu();
                    break;
                case AppAction.GoLeftOneColumn:
                    _board.MoveLeft();
                    _menuView.LeaveMenu();
                    break;
                case AppAction.GoRightOneColumn:
                    _board.MoveRight();
                    _menuView.LeaveMenu();
                    break;
                case AppAction.NextSetting:
                    _settings.ToggleValueSelected();
                    break;
                case AppAction.NextLoadGame:
                    _loadView.NextGame();
                    break;
                case AppAction.Decrement:
                    _settings.DecreaseValue();
                    break;
                case AppAction.Increment:
                    _settings.IncreaseValue();
                    break;
                case AppAction.SaveTheGame:
                    _isPaused = true;
                    _menuView.LeaveMenu();
                    _menuView.GoToMenu(MenuType.GameSaveMenu);
                    break;
                case AppAction.Confirm when _menuView.IsMenu(MenuType.GameSaveMenu):
                    _loadView.GameSave(_board, previous_input);
                    _menuView.LeaveMenu();
                    _isPaused = false;
                    break;
                case AppAction.Confirm when _menuView.IsMenu(MenuType.GameLoadMenu):
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
            if (All(Tie))
            {
                _endView.WhoWon = Tie;
                _isPaused = true;
                _menuView.GoToMenu(MenuType.GameEndMenu);
            } else if (All(XWon))
            {
                _endView.WhoWon = XWon;
                _isPaused = true;
                _menuView.GoToMenu(MenuType.GameEndMenu);
            } else if (All(OWon))
            {
                _endView.WhoWon = OWon;
                _isPaused = true;
                _menuView.GoToMenu(MenuType.GameEndMenu);
            } else if (All(XTurn, LeftMostSelected))
            {
                _menuView.GoToMenu(MenuType.XRightGameMenu);
            }
            else if (All(XTurn, RightMostSelected))
            {
                _menuView.GoToMenu(MenuType.XLeftGameMenu);
            }
            else if (All(OTurn, LeftMostSelected))
            {
                _menuView.GoToMenu(MenuType.ORightGameMenu);
            }
            else if (All(OTurn, RightMostSelected))
            {
                _menuView.GoToMenu(MenuType.OLeftGameMenu);
            }
            else if (All(OTurn))
            {
                _menuView.GoToMenu(MenuType.OGameMenu);
            }
            else if (All(XTurn))
            {
                _menuView.GoToMenu(MenuType.XGameMenu);
            }
            else if (All(LeftMostSelected))
            {
                _menuView.GoToMenu(MenuType.RightGameMenu);
            }
            else if (All(RightMostSelected))
            {
                _menuView.GoToMenu(MenuType.LeftGameMenu);
            }
            else
            {
                _menuView.GoToMenu(MenuType.GameMenu);
            }
        }

        private bool All(params GameState[] statesToCheck)
        {
            return statesToCheck.All(_gameStates.Contains);
        }
    }
}