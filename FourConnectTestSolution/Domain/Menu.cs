using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Menu
    {
        public int MenuId { get; set; }

        [Required]
        public MenuType MenuType { get; set; } = default!;
        [Required]
        public string Title { get; set; } = default!;

        public ICollection<MenuItemsInMenu>? MenuItemsInMenu { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}