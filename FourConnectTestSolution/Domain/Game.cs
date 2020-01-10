using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Game;
namespace Domain
{

    public class Game
    {
        public int GameId { get; set; }
        [MaxLength(20)]
        [Required]
        public string GameName { get; set; } = default!;
        [Required]
        public DateTime TimeSaved { get; set; }
        [Required]
        public CellType FirstMove { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int SelectedColumn { get; set; }
        public ICollection<Move> Moves { get; set; } = default!;
    }
}