namespace FourConnectCore.MenuItems
{
    public class SaveGame : MenuItem
    {
        public SaveGame()
        {
            Title = "Save";
            ActionToTake = MenuAction.SaveTheGame;
        }
    }
}