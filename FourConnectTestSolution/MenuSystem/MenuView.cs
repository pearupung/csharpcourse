using System.Collections.Generic;

namespace FourConnectCore
{
    public class MenuView
    {
        private Stack<Menu> _menuStack = new Stack<Menu>();
        
        public virtual void ConstructMenuView() {}

        public virtual void PickMenuItem()
        {
        }

        public virtual void ReturnToPrevious()
        {
        }

        public virtual void ReturnToMain()
        {
        }

        public virtual void Exit()
        {
        }
        
        
    }
}