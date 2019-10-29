using System;

namespace FourConnectCore
{
    public class SavedGame
    {
        public GameBoard? GameBoard { get; set; }
        public string? GameName { get; set; }
        public DateTime TimeSaved { get; set; }
    }
}