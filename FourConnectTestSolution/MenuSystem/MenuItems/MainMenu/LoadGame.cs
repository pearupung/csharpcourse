namespace FourConnectCore.MenuItems
{
    public class LoadGame : MenuItem
    {
        public LoadGame()
        {
            Title = "Load game";
            ActionToTake = MenuAction.GoToLoadGameMenu;

        }
    }
}