namespace FourConnectCore.MenuItems
{
    public class LocalMultiPlayer : MenuItem
    {
        public LocalMultiPlayer()
        {
            Title = "Initiate gameplay against a local foe";
            ActionToTake = MenuAction.PlayAgainstALocalPlayer;
        }
    }
}