namespace Minesweeper.Domain.Exception
{
    public class GameOverException : System.Exception
    {
        public GameOverException() : base(Properties.Resources.GameOverMessage)
        {
        }
    }
}
