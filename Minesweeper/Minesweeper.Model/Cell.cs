using Minesweeper.Library.Exceptions;
using System;

namespace Minesweeper.Model
{
    public class Cell
    {
        public Cell(bool hasBomb)
        {
            HasBomb = hasBomb;
            Status = StatusEnum.Untouched;
        }

        public bool HasBomb { get; private set; }
        public StatusEnum Status { get; private set; }
        public int QuantityBombsNear { get; private set; }

        public void Flagged()
        {
            Status = StatusEnum.Flagged;
        }

        public void Check()
        {
            if (HasBomb)
                throw new GameOverException();
            Status = StatusEnum.Revealed;
        }
    }
}
