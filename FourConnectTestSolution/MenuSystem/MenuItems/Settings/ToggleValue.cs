namespace FourConnectCore.MenuItems
{
    public class ToggleValue : MenuItem
    {
        public ToggleValue()
        {
            Title = "Toggle to the next setting";
            ActionToTake = MenuAction.NextSetting;
        }
    }
}