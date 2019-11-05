using System.Linq;
using DAL;
using Domain;
using Game;

namespace FourConnectCore
{
    class Program
    {
      
        static void Main(string[] args)
        {
//            using (var ctx =new AppDbContext())
//            {
//                foreach (var menuItemsInMenu in ctx.MenuItemsInMenus.Where(m => m.MenuItem.Title.Equals("Delete")))
//                {
//                    ctx.MenuItemsInMenus.Remove(ctx.MenuItemsInMenus.Find(menuItemsInMenu.MenuItemsInMenuId));
//                }
//
//                var menu = ctx.Menus.Add(new Menu()
//                {
//                    MenuType = MenuType.GameDeleteLoadMenu,
//                    Title = "Load Game",
//                });
//
//                foreach (var itemKey in new int[]{9, 22, 24})
//                {
//                    var rel = new MenuItemsInMenu()
//                    {
//                        Menu = menu.Entity,
//                        MenuItem = ctx.MenuItems.Find(itemKey)
//                    };
//                    
//                    ctx.MenuItemsInMenus.Add(rel);
//                }
//
//                ctx.SaveChanges();

//            }
            var app = new ConsoleApp();
            app.RunApp();
        }

       

        private static bool HasFourConnected(GameBoard board, CellType cellType)
        {
            var array = board.ToArray();
            
            var findDirections = new (int row, int col)[]
            {
                (-1,-1), (-1, 0), (-1, 1),
                (0, -1), (0, 1),
                (1, -1), (1, 0), (1, 1)
            };
            
            for (var row = 0; row < array.GetLength(0); row++)
            for (var col = 0; col < array.GetLength(1); col++)
            {
                var cell = array[row, col];
                var coords = (row, col);
                if (cell == CellType.Empty) continue;
                foreach (var findDirection in findDirections)
                {
                    var hasFour = HasFourConnected(1, board, coords, CellType.X, findDirection);
                    if (hasFour) return true;
                }
            }

            return false;
        }
        
        private static bool HasFourConnected(int connectedCount, 
            GameBoard board, 
            (int row, int col) coords, 
            CellType cellType, 
            (int row, int col) searchDirection)
        {
            if (connectedCount == 4 || connectedCount > 4)
            {
                return true;
            }
            var (row, col) = coords;
            var (rowMask, colMask) = searchDirection;
            var newCoords = (row + rowMask, col + colMask);

            if (board.InBounds(newCoords))
            {
                if (board.GetCellType(newCoords) == cellType)
                {
                    return HasFourConnected(connectedCount+1, board, newCoords, cellType, searchDirection);
                }
            }
            
            return false;
        } 

    }
}