using System;
using System.Collections.Generic;

namespace FourConnectCore
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoard board = new GameBoard(4, 4);
            
            board.add(1, CellType.O);
            board.add(2, CellType.X);
            
            Console.WriteLine(board);
            
        }
    }
}