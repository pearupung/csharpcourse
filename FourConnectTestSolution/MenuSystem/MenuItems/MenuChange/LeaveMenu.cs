namespace FourConnectCore.MenuItems
{
    public class LeaveMenu : MenuItem
    {
        public LeaveMenu()
        {
            Title = "Return to previous menu";
            VisibleFromLevel = 2;
            ActionToTake = MenuAction.LeaveMenu;
        }
    }
}