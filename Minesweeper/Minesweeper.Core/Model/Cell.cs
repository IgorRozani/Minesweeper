using Minesweeper.Domain.Enumerator;
using Minesweeper.Library.Exception;
using System;

namespace Minesweeper.Domain.Model
{
    public class Cell : IEquatable<Cell>
    {
        public Cell()
        {
            Status = StatusEnum.Untouched;
        }

        public bool HasBomb { get; private set; }
        public StatusEnum Status { get; private set; }
        public int QuantityBombsNear { get; private set; }

        public void SetBomb()
        {
            if (!IsUntouched())
                throw new MinesweeperException(Properties.Resources.CellIsCheckedPlaceBomb);

            HasBomb = true;
        }

        public void SetQuantityBombsNear(int quantityBombsNear)
        {
            if (!IsUntouched())
                throw new MinesweeperException(Properties.Resources.CellIsCheckedBombsNear);

            QuantityBombsNear = quantityBombsNear;
        }

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

        public bool Equals(Cell other)
        {
            if (other == null)
                return false;
            return HasBomb == other.HasBomb && Status == other.Status && QuantityBombsNear == other.QuantityBombsNear;
        }

        private bool IsUntouched()
        {
            return Status == StatusEnum.Untouched;
        }
    }
}
