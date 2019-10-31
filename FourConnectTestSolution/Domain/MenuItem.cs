using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        [Required]
        public string Title { get; set; } = default!;
        [Required]
        public AppAction AppActionToTake { get; set; } = default!;
        public ICollection<MenuItemsInMenu>? MenuItemsInMenus { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}