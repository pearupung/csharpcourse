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
        public LoadGameView LoadGameView { get; set; } = new LoadGameView();
        public CellType[,] GameBoardArray { get; set; }



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

        }

        public IActionResult OnPost(int menuItemPushed, 
            List<int> hiddenPlayedColumnsList, 
            int[] settings, List<GameState> hiddenGameStates,
            MenuType[] hiddenMenuStack)
        {
            Console.WriteLine("MachinePlay on post start: " +MachinePlay);

            foreach (var menuType in hiddenMenuStack)
            {
                Console.WriteLine("Here the menutype: " + menuType);
            }
            Settings = Settings.GetSettings();
            if (settings != null)
            {
                
                Settings.settings = new GameSetting[]
                {
                    new GameSetting("Board Height", settings[0]), 
                    new GameSetting("Board Width", settings[1]), 
                };
                
            }

            MenuView.ReconstructMenuStack(hiddenMenuStack);
            GameStates = hiddenGameStates;
            GameBoard.PlayedColumns = hiddenPlayedColumnsList;
            GameBoard.Board = LoadGameView.CreateBoardFromPlayedColumns(GameBoard.FirstMove, GameBoard.Height,
                GameBoard.Width, hiddenPlayedColumnsList);
            Console.WriteLine(MenuView.MenuItems.Count);
            Console.WriteLine(menuItemPushed);
            if (!(menuItemPushed < MenuView.MenuItems.Count))
            {
                return Page();
            }

            var appAction = MenuView.MenuItems[menuItemPushed].AppActionToTake;
            foreach (var menuType in hiddenMenuStack)
            {
                Console.WriteLine("Here the menutype in menustack: " + menuType);
            }

            Console.WriteLine(appAction);
            Console.WriteLine(IsPaused);
            Console.WriteLine("MachinePlay before logic: " +MachinePlay);
            var app = ConsoleApp.GetAppStateUponAction(GameBoard, MenuView, Settings, IsPaused, 
                appAction, MachinePlay, Input,
                GameStates, LoadGameView);
            Console.WriteLine(MenuView.MenuItems);
            GameBoard = app.GameBoard;
            GameBoardArray = GameBoard.ToArray();
            MenuView = app.MenuView;
            foreach (var type in MenuView.MenuTypeIntegersPath)
            {
                Console.WriteLine("Here is the menutype after: "+(MenuType) type);
                
            }
            Settings = app.Settings;
            IsPaused = app.Ispaused;
            Console.WriteLine(IsPaused);
            MachinePlay = app.MachinePlay;
            Console.WriteLine("MachinePlay: " + MachinePlay);
            GameStates = app.GameStates;
            LoadGameView = app.LoadView;
            Console.WriteLine(GameBoard);
            return Page();

        }
    }
}