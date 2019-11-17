using System.ComponentModel.DataAnnotations;
using Game;

namespace Domain
{
    public class Move
    {
        public int MoveId { get; set; }
        [Required]
        
        public int Column { get; set; }
        public int GameId { get; set; }
        [Required]
        public Game Game { get; set; } = default!;
    }
}