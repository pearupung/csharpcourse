using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourConnectCore
{
    public class GameBoard
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public Stack<CellType>[] Board { get; set; } = default!;
        
        public int SelectedColumn { get; set; }

        public GameBoard()
        {}
        
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

            Board = new Stack<CellType>[Width];
            for (var i = 0; i < width; i++)
            {
                Board[i] = new Stack<CellType>(Height);
            }

            SelectedColumn = 0;
        }

        public GameBoard(GameBoard board)
        {
            Height = board.Height;
            Width = board.Width;
            Board = board.Board;
            SelectedColumn = board.SelectedColumn;

        }


        public void Add(int column, CellType celltype)
        {
            if (Board[column].Count < Height)
            {
                Board[column].Push(celltype);
            }
        }

        public void MoveLeft()
        {
            if (SelectedColumn > 0)
            {
                SelectedColumn--;
            }
        }

        public void MoveRight()
        {
            if (SelectedColumn < Width - 1)
            {
                SelectedColumn++;
            }
        }
        
        public void PutX ()
        {
            Add(SelectedColumn, CellType.X);
        }
        
        public void PutO ()
        {
            Add(SelectedColumn, CellType.O);
        }
        
        public CellType[,] ToArray()
        {
            var board = new CellType[Height, Width];
            for (var i = 0; i < Width; i++)
            {
                var column = Board[i].Reverse().ToArray();
                for (var j = 0; j < Height; j++)
                {
                    board[j, i] = Height - 1 - j < column.Length ? column[Height - 1 - j] : CellType.Empty;
                }
            }

            return board;
        }

        public override string ToString()
        {
            var board = this.ToArray();
            var rowSeparator = new string('-', (Width+1)*4) + "\n";
            var colSeparator = " | ";
            var selectedSeparator = " |>";
            var stringBuilder = new StringBuilder();

            for (var i = 0; i < Height; i++)
            {
                stringBuilder.Append(rowSeparator);
                for (var j = 0; j < Width; j++)
                {
                    if (SelectedColumn == j)
                    {
                        stringBuilder.Append(selectedSeparator);
                    }
                    else
                    {
                        stringBuilder.Append(colSeparator);
                    }
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