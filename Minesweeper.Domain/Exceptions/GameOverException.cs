using System;

namespace Minesweeper.Domain.Exceptions
{
    public class GameOverException : Exception
    {
        public GameOverException() : base(Properties.Resources.GameOverMessage)
        {
        }
    }
}
