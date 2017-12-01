using Minesweeper.Domain.Enumerator;
using Minesweeper.Domain.Exception;
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

            if (HasBomb)
                throw new MinesweeperException(Properties.Resources.FieldAlreadyHasBomb);

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
            if (IsRevealed())
                throw new MinesweeperException(Properties.Resources.CellIsReavealed);
            Status = StatusEnum.Flagged;
        }

        public void Unflag()
        {
            if (!IsFlagged())
                throw new MinesweeperException(Properties.Resources.UnflagCellWithoutFlag);

            Status = StatusEnum.Untouched;
        }

        public void Check()
        {
            if (IsRevealed())
                throw new MinesweeperException(Properties.Resources.CellIsReavealed);

            if (IsFlagged())
                throw new MinesweeperException(Properties.Resources.CellIsFlagged);

            Status = StatusEnum.Revealed;

            if (HasBomb)
                throw new GameOverException();
        }

        private bool IsUntouched()
        {
            return Status == StatusEnum.Untouched;
        }

        public bool IsFlagged()
        {
            return Status == StatusEnum.Flagged;
        }

        public bool IsRevealed()
        {
            return Status == StatusEnum.Revealed;
        }

        public bool IsFlagOrUntouched()
        {
            return IsUntouched() || IsFlagged();
        }

        public bool Equals(Cell other)
        {
            if (other == null)
                return false;
            return HasBomb == other.HasBomb && Status == other.Status && QuantityBombsNear == other.QuantityBombsNear;
        }
    }
}
