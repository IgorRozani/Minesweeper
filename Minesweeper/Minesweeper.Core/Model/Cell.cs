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

        public void Flag()
        {
            Status = StatusEnum.Flagged;
        }

        public void Unflag()
        {
            if (Status != StatusEnum.Flagged)
                throw new MinesweeperException(Properties.Resources.UnflagCellWithoutFlag);

            Status = StatusEnum.Untouched;
        }

        public void Check()
        {
            if (Status == StatusEnum.Revealed)
                throw new MinesweeperException(Properties.Resources.CheckCellReavealed);

            Status = StatusEnum.Revealed;

            if (HasBomb)
                throw new GameOverException();
        }

        private bool IsUntouched()
        {
            return Status == StatusEnum.Untouched;
        }

        public bool Equals(Cell other)
        {
            if (other == null)
                return false;
            return HasBomb == other.HasBomb && Status == other.Status && QuantityBombsNear == other.QuantityBombsNear;
        }
    }
}
