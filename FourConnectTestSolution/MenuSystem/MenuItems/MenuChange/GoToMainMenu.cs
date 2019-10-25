namespace FourConnectCore.MenuItems
{
    public class GoToMainMenu : MenuItem
    {
        public GoToMainMenu()
        {
            Title = "Return to main menu";
            VisibleFromLevel = 1;
            ActionToTake = MenuAction.GoToMainMenu;
        }
    }
}