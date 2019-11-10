using System;
using System.Collections;
using System.Collections.Generic;
using Game;

namespace Domain
{
    public class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; } = default!;
        public DateTime TimeSaved { get; set; }
        public CellType FirstMove { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int SelectedColumn { get; set; }
        public ICollection<Move> Moves { get; set; } = default!;
    }
}