using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FourConnectCore
{
    public class GameBoard
    {
        private int Height { get; }
        private int Width { get; }
        private Stack<CellType>[] Board;
        

        public GameBoard(int height, int width)
        {
            Height = height;
            Width = width;
            if (height < 4 || width < 4)
            {
                throw new ArgumentException($"Invalid size for board: " +
                                            $"one of width ({height}) or height ({height}) " +
                                            $"must be more than 3.");
            }

            Height = height;
            Width = width;

            Board = new Stack<CellType>[width];
            for (var i = 0; i < width; i++)
            {
                Board[i] = new Stack<CellType>(height);
            }
        }


        public void add(int column, CellType celltype)
        {
            Board[column].Push(celltype);
        }

        public CellType[,] ToArray()
        {
            var board = new CellType[Width, Height];
            for (var i = 0; i < Width; i++)
            {
                var column = Board[i].ToArray();
                for (var j = 0; j < Height; j++)
                {
                    board[3 - j, i] = j < column.Length ? column[j] : CellType.Empty;
                }
            }

            return board;
        }

        public override string ToString()
        {
            var board = this.ToArray();
            var rowSeparator = new string('-', Width*2 + 1) + "\n";
            var colSeparator = "|";
            var stringBuilder = new StringBuilder();

            for (var i = 0; i < Width; i++)
            {
                stringBuilder.Append(rowSeparator);
                for (var j = 0; j < Height; j++)
                {
                    stringBuilder.Append(colSeparator);
                    var cell = board[i,j];
                    if (cell == CellType.Empty)
                    {
                        stringBuilder.Append(" ");
                    }
                    else
                    {
                        stringBuilder.Append(cell);
                    }

                }

                stringBuilder.Append(colSeparator + "\n");

            }

            stringBuilder.Append(rowSeparator);
            return stringBuilder.ToString();
        }

    }
    
}