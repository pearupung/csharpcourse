namespace FourConnectCore.MenuItems
{
    public class Exit : MenuItem
    {
        public Exit()
        {
            Title = "Exit";
            VisibleFromLevel = 0;
            ActionToTake = MenuAction.Exit;
        }
    }
}