using System;

namespace Minesweeper.Domain.Exceptions
{
    public class MinesweeperException : Exception
    {
        public MinesweeperException(string message) : base(message)
        {
        }
    }
}