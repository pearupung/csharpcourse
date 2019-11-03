using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace MenuSystem
{
    public sealed class MenuView
    {
        private readonly Stack<Menu> _menuStack = new Stack<Menu>();
        private readonly Menu _startMenu;
        private List<MenuItem> _menuItems;

        public string[] MenuTypePath => _menuStack.Select(menu => menu.MenuType.ToString()).ToArray();
        public string[] Path => _menuStack.Select(menu => menu.Title).ToArray();
        
        private Menu GetMenu(MenuType type)
        {
            using (var ctx = new AppDbContext())
            {
                var queryable = ctx.Menus.Include(menu => menu.MenuItemsInMenu)
                    .ThenInclude(men => men.MenuItem)
                    .Where(m => m.MenuType == type);
                return queryable.ToArray()[0];
            }
        }
        
        private MenuItem GetMenuItem(AppAction action)
        {
            using (var ctx = new AppDbContext())
            {
                IQueryable<MenuItem> dbSet = ctx.MenuItems;
                return dbSet.AsEnumerable().Where(m => m.AppActionToTake == action).ToArray()[0];
            }
        }

        public MenuView()
        {
            _startMenu = GetMenu(MenuType.MainMenu);
            GoToMenu(_startMenu);
        }

        public List<MenuItem> GetMenuItems()
        {
            var list = new List<MenuItem>();

            foreach (var menuItemsInMenu in Menu.MenuItemsInMenu)
            {
                list.Add(menuItemsInMenu.MenuItem);
            }
            
            if(MenuStackSize > 0)
            {
                list.Add(GetMenuItem(AppAction.Exit));
            }
            if (MenuStackSize > 1)
            {
                list.Add(GetMenuItem(AppAction.GoToMainMenu));
            }
            if(MenuStackSize > 2)
            {
                list.Add(GetMenuItem(AppAction.LeaveMenu));
            }

            return list;
        }

        public bool IsMenu(MenuType type) => type == MenuType;
        public MenuType MenuType => Menu.MenuType;

        public int MenuStackSize => _menuStack.Count;
        public Menu Menu => _menuStack.Peek();

        public List<MenuItem> MenuItems => _menuItems;

        public AppAction PickMenuItem(MenuItem menuItem)
        {
            if (MenuItems.Contains(menuItem))
            {
                return menuItem.AppActionToTake;
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
            _menuItems = GetMenuItems();
        }
        
        public void GoToMenu(MenuType type)
        {
            var menu = GetMenu(type);
            GoToMenu(menu);
        }

        public void LeaveMenu()
        {
            _menuStack.Pop();
            _menuItems = GetMenuItems();
        }

        public void GoToMainMenu()
        {
            _menuStack.Clear();
            GoToMenu(_startMenu);
        }

        public void Exit()
        {
            _menuStack.Clear();
        }
    }
}