using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FourConnectCore
{
    public class MenuView
    {
        private Stack<Menu> _menuStack = new Stack<Menu>();
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

        public virtual void PickMenuItem(MenuItem menuItem)
        {
            if (MenuItems.ContainsValue(menuItem))
            {
                menuItem.CommandToExecute();
            }
        }

        public virtual void GoToMenu(Menu menu)
        {
            _menuStack.Push(menu);
        }

        public virtual void LeaveMenu()
        {
            _menuStack.Pop();
        }

        public virtual void GoToMainMenu()
        {
            _menuStack.Clear();
            _menuStack.Push(_startMenu);
        }

        public virtual void Exit()
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