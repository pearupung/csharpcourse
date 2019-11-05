using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using MenuSystem;

namespace FourConnectCore
{
    public class ConsoleUi
    {
        public static void ShowMenu(MenuView menuView, Dictionary<AppAction, string> actionToStringMapping)
        {
            
            var longTitleBuilder = new StringBuilder();
            foreach (var menu in menuView.MenuTypePath)
            {
                longTitleBuilder.Insert(0, $"/{menu}");
            }
            
            var builder = new StringBuilder();
            builder.Append(longTitleBuilder);
            builder.AppendLine();
            builder.Append("==================");
            builder.AppendLine();

            foreach (var menuItem in menuView.MenuItems)
            {
                builder.Append(actionToStringMapping[menuItem.AppActionToTake]);
                builder.Append(" ");
                builder.Append(menuItem);
                builder.AppendLine();
            }
            builder.Append("--------------");
            builder.AppendLine();
            Console.WriteLine(builder.ToString());
        }
    }
}