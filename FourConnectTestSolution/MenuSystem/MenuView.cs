using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FourConnectCore
{
    public sealed class MenuView
    {
        private readonly Stack<Menu> _menuStack = new Stack<Menu>();
        private Menu _startMenu;
        public int MenuStackSize => _menuStack.Count;
        public Menu Menu => _menuStack.Peek();

        public Dictionary<string, MenuItem> MenuItems =>
            _menuStack.Peek().MenuItemsDictionary;

        public void SetStartMenu(Menu menu)
        {
            _startMenu = menu;
            _menuStack.Push(_startMenu);
        }
        
        public MenuView()
        {
        }

        public MenuAction PickMenuItem(MenuItem menuItem)
        {
            if (MenuItems.ContainsValue(menuItem))
            {
                if (Menu.TogglableMenuItems.ContainsKey(menuItem))
                {
                    Menu.ToggleMenuItems(menuItem);
                }
                return menuItem.ActionToTake;
            }
            return MenuAction.Chill;
        }

        public void GoToMenu(Menu menu)
        {
            _menuStack.Push(menu);
            menu.MenuLevel = MenuStackSize - 1;
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
            var builder = new StringBuilder();
            builder.Append(Menu.Title);
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