using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourConnectCore
{
    public class GameBoard
    {
        private int Height { get; }
        private int Width { get; }
        private Stack<CellType>[] Board;
        public int SelectedColumn { get; set; }
        public Func<CellType[,], GameState> GetGameState;
        private readonly string PreviousMenuCommand = "M";

        public GameBoard(int height, int width, Func<CellType[,], GameState> getGameState)
        {
            Height = height;
            Width = width;
            GetGameState = getGameState;
            if (height < 4 || width < 4)
            {
                throw new ArgumentException($"Invalid size for board: " +
                                            $"one of width ({height}) or height ({height}) " +
                                            $"must be more than 3.");
            }

            Height = height;
            Width = width;

            Board = new Stack<CellType>[Height];
            for (var i = 0; i < width; i++)
            {
                Board[i] = new Stack<CellType>(Height);
            }
        }


        public void Add(int column, CellType celltype)
        {
            if (Board[column].Count < Height)
            {
                Board[column].Push(celltype);
            }
            else
            {
                Console.WriteLine($"Cell type {celltype} not added to stack.");
            }
        }

        public string MoveLeft()
        {
            if (SelectedColumn > 0)
            {
                SelectedColumn--;
            }

            return null;
        }

        public string MoveRight()
        {
            if (SelectedColumn < Width - 1)
            {
                SelectedColumn++;
            }

            return null;
        }
        
        public string PutX ()
        {
            Add(SelectedColumn, CellType.X);
            return GetGameState(this.ToArray()) != GameState.InProgress ? PreviousMenuCommand : "";
        }
        
        public string PutO ()
        {
            Add(SelectedColumn, CellType.O);
            return GetGameState(this.ToArray()) != GameState.InProgress ? PreviousMenuCommand : "";
        }
        
        public CellType[,] ToArray()
        {
            var board = new CellType[Width, Height];
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

            for (var i = 0; i < Width; i++)
            {
                stringBuilder.Append(rowSeparator);
                for (var j = 0; j < Height; j++)
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