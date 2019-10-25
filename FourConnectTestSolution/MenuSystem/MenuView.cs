using System.Collections.Generic;
using System.Linq;

namespace FourConnectCore
{
    public class MenuView
    {
        private Stack<Menu> _menuStack = new Stack<Menu>();
        private Menu _startMenu;
        public List<MenuItem> MenuItems =>
            _menuStack.Peek()
                .MenuItemsDictionary.Values.ToList();

        public virtual void ConstructMenuView()
        {
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
                }
            };
            var settingsMenu = new Menu(1)
            {
                GetGraphic = settings.ToString,
                MenuItemsDictionary = new Dictionary<string, MenuItem>()
                {
                    {
                        "T", 
                        new MenuItem()
                    {
                        Title = "Toggle value to be set",
                        CommandToExecute = settings.ToggleValueSelected,
                    }},
                    {
                        "+", new MenuItem()
                        {
                            Title = "Increase value",
                            CommandToExecute = settings.IncreaseValue
                        }
                    },
                    {
                        "-", new MenuItem()
                        {
                            Title = "Decrease value",
                            CommandToExecute = settings.DecreaseValue
                        }
                    }
                    
                }
            };
            
            var menu0 = new Menu(0)
            {
                Title = "GameEngine main menu",
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
                            Title =  "Change board size",
                            CommandToExecute = settingsMenu.Run
                            
                        }
                    }
                }
            };

            _startMenu = menu0;
        }

        public MenuView()
        {
            _menuStack.Push(_startMenu);
        }

        public virtual void PickMenuItem()
        {
        }

        public virtual void ReturnToPrevious()
        {
            _menuStack.Pop();
        }

        public virtual void ReturnToMain()
        {
            _menuStack.Clear();
            _menuStack.Push(_startMenu);
        }

        public virtual void Exit()
        {
            _menuStack.Clear();
        }
        
        
    }
}