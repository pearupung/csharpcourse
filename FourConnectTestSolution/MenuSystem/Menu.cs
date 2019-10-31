using System.Collections.Generic;
using FourConnectCore;
using FourConnectCore.Domain;

namespace MenuSystem
{
    public class Menu
    {
        public string Name { get; set; } = default!;
        public string Title { get; set; } = default!;

        public Dictionary<string, MenuItem> MenuItemsDictionary { get; set; } = new Dictionary<string, MenuItem>();
        public AppAction GetActionForInput(string str)
        {
            if (this.MenuItemsDictionary.ContainsKey(str))
            {
                return this.MenuItemsDictionary[str].ActionToTake;
            }
            else
            {
                return AppAction.Chill;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}