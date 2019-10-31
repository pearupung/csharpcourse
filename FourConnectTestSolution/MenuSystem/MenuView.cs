using System;
using System.Collections.Generic;
using System.Text;
using FourConnectCore;
using FourConnectCore.Domain;
using MenuSystem.Factory;

namespace MenuSystem
{
    public sealed class MenuView
    {
        private readonly Stack<Menu> _menuStack = new Stack<Menu>();
        private readonly Menu _startMenu;
        private readonly MenuFactory _menuFactory = new MenuFactory();
        private readonly MenuItemFactory _menuItemFactory = new MenuItemFactory();

        public MenuView(Menu startMenu)
        {
            _startMenu = startMenu;
            GoToMenu(_startMenu);
        }

        public MenuView()
        {
            _startMenu = _menuFactory.GetMenu("MainMenu");
            GoToMenu(_startMenu);
        }

        public bool IsMenu(string name) => Menu.Name.Equals(name);

        public int MenuStackSize => _menuStack.Count;
        public Menu Menu => _menuStack.Peek();

        public Dictionary<string, MenuItem> MenuItems =>
            Menu.MenuItemsDictionary;
        
        public AppAction PickMenuItem(MenuItem menuItem)
        {
            if (MenuItems.ContainsValue(menuItem))
            {
                return menuItem.ActionToTake;
            }
            return AppAction.Chill;
        }

        private void GoToMenu(Menu menu)
        {
            if (_menuStack.Contains(menu))
            {
                throw new Exception("This menu has already been added.");
            }
            _menuStack.Push(menu);
            if(MenuStackSize > 0)
            {
                menu.MenuItemsDictionary.Add("E", _menuItemFactory.GetMenuItem("ExitProgram"));
            }
            if (MenuStackSize > 1)
            {
                menu.MenuItemsDictionary.Add("M", _menuItemFactory.GetMenuItem("GoToMainMenu"));
            }
            if(MenuStackSize > 2)
            {
                menu.MenuItemsDictionary.Add("P", _menuItemFactory.GetMenuItem("LeaveMenu"));
            }
        }
        
        public void GoToMenu(string menuName)
        {
            var menu = _menuFactory.GetMenu(menuName);
            GoToMenu(menu);
        }

        public void LeaveMenu()
        {
            _menuStack.Pop();
        }

        public void GoToMainMenu()
        {
            _menuStack.Clear();
            _menuStack.Push(_startMenu);
        }

        public void Exit()
        {
            _menuStack.Clear();
        }

        public override string ToString()
        {
            var longTitleBuilder = new StringBuilder();
            foreach (var menu in _menuStack.ToArray())
            {
                longTitleBuilder.Insert(0, $"> {menu.Name}");
            }
            var builder = new StringBuilder();
            builder.Append(longTitleBuilder);
            builder.AppendLine();
            builder.Append("==================");
            builder.AppendLine();

            foreach (var (comm, menuItem) in MenuItems)
            {
                builder.Append(comm);
                builder.Append(" ");
                builder.Append(menuItem);
                builder.AppendLine();
            }
            builder.Append("--------------");
            builder.AppendLine();
            return builder.ToString();
        }
    }
}