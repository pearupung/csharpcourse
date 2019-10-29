using System;
using System.Collections.Generic;
using System.Linq;

namespace FourConnectCore
{
    public class Menu
    {
        public string Name { get; set; } = default!;
        public string Title { get; set; } = default!;

        private Dictionary<string, MenuItem> _menuItemsDictionary = 
            new Dictionary<string, MenuItem>();
        public Dictionary<string, MenuItem> MenuItemsDictionary
        {
            get => _menuItemsDictionary; 
            set => _menuItemsDictionary = value;
            
        }

        public override string ToString()
        {
            return Name;
        }
    }
}