using System;
using System.Collections.Generic;
using System.Linq;

namespace FourConnectCore
{
    public class Menu
    {
        public string Name { get; set; } = default!;
        public string Title { get; set; } = default!;

        public Dictionary<string, MenuItem> MenuItemsDictionary { get; set; } = new Dictionary<string, MenuItem>();
        public MenuAction GetActionForInput(string str)
        {
            if (this.MenuItemsDictionary.ContainsKey(str))
            {
                return this.MenuItemsDictionary[str].ActionToTake;
            }
            else
            {
                return MenuAction.Chill;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}