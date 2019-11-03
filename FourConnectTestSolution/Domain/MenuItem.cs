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
        [Required] public int AppActionId { get => (int) this.AppActionToTake; 
            set => AppActionToTake = (AppAction) value; }
        [EnumDataType(typeof(AppAction))]
        public AppAction AppActionToTake { get; set; } = default!;
        public ICollection<MenuItemsInMenu>? MenuItemsInMenus { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}