using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Domain
{
    public class MenuItemsInMenu
    {
        public int MenuItemsInMenuId { get; set; }
        public int MenuId { get; set; }
        [Required]
        public Menu Menu { get; set; } = default!;
        [Required]
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; } = default!;
    }
}