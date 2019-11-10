using Game;

namespace Domain
{
    public class Move
    {
        public int MoveId { get; set; }
        public int Column { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; } = default!;
    }
}