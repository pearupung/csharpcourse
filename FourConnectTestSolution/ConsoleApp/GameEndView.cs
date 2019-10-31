using Game;

namespace FourConnectCore
{
    public class GameEndView
    {
        public GameState WhoWon { get; set; }

        public override string ToString()
        {
            string endGameString = "I do not know who won.";
            if (WhoWon == GameState.Tie)
            {
                endGameString = "This is a tie!";
            } else if (WhoWon == GameState.OWon)
            {
                endGameString = "Player O won this time around!";
            }
            else if (WhoWon == GameState.XWon)
            {
                endGameString = "Player X turned in as a winner!";
            }

            return endGameString;
        }
    }
}