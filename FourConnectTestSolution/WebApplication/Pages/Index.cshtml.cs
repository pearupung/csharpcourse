using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FourConnectCore;
using Game;
using MenuSystem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public GameBoard GameBoard { get; set; }
        [BindProperty] public MenuView MenuView { get; set; }
        public Settings Settings { get; set; }
        [BindProperty] public bool IsPaused { get; set; }
        [BindProperty] public bool MachinePlay { get; set; }
        [BindProperty] public string Input { get; set; }
        public List<GameState> GameStates { get; set; }
        [BindProperty] public LoadGameView LoadGameView { get; set; } = new LoadGameView();
        public CellType[,] GameBoardArray { get; set; }
        public List<Domain.Game> Games { get; set; }
        public GameEndView GameEndView { get; set; }



        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            GameBoard = new GameBoard(4,4);
            GameBoardArray = GameBoard.ToArray();
            MenuView = new MenuView();
            Settings = Settings.GetSettings();
            IsPaused = true;
            MachinePlay = false;
            GameStates = new List<GameState>();
            LoadGameView = new LoadGameView();
            Games = LoadGameView.GetGames();
            GameEndView = new GameEndView();

        }

        public IActionResult OnPost(int menuItemPushed, 
            List<int> hiddenPlayedColumnsList, 
            int[] settings, List<GameState> hiddenGameStates,
            MenuType[] hiddenMenuStack)
        {
            Settings = Settings.GetSettings();
            if (settings != null)
            {
                for (var i = 0; i < settings.Length; i++)
                {
                    Settings.settings[i].Value = settings[i];
                }
            }

            MenuView.ReconstructMenuStack(hiddenMenuStack);
            GameStates = hiddenGameStates;
            GameBoard.PlayedColumns = hiddenPlayedColumnsList;
            GameBoard.Board = LoadGameView.CreateBoardFromPlayedColumns(GameBoard.FirstMove, GameBoard.Height,
                GameBoard.Width, hiddenPlayedColumnsList);
            if (!(menuItemPushed < MenuView.MenuItems.Count))
            {
                return Page();
            }

            var appAction = MenuView.MenuItems[menuItemPushed].AppActionToTake;
            
            var app = ConsoleApp.GetAppStateUponAction(GameBoard, MenuView, Settings, IsPaused, 
                appAction, MachinePlay, Input,
                GameStates, LoadGameView);
            GameBoard = app.GameBoard;
            GameBoardArray = GameBoard.ToArray();
            MenuView = app.MenuView;
            GameEndView = app.GameEndView;
            
            if (MenuView.MenuStackSize == 0)
            {
                return Redirect("./End");
            }
            Settings = app.Settings;
            IsPaused = app.Ispaused;
            MachinePlay = app.MachinePlay;
            GameStates = app.GameStates;
            LoadGameView = app.LoadView;
            Games = LoadGameView.GetGames();
            return Page();

        }
    }
}