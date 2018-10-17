using Minesweeper.Domain.Enums;
using Minesweeper.Domain.Exceptions;
using System;

namespace Minesweeper.Domain.Models
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

        private bool IsUntouched() => Status == StatusEnum.Untouched;

        public bool IsFlagged() => Status == StatusEnum.Flagged;

        public bool IsRevealed() => Status == StatusEnum.Revealed;
        
        public bool Equals(Cell other) =>
            other != null && HasBomb == other.HasBomb && Status == other.Status && QuantityBombsNear == other.QuantityBombsNear;
    }
}
