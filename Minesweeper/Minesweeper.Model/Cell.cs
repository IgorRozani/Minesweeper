﻿using Minesweeper.Library.Exception;
using Minesweeper.Model.Enumerator;

namespace Minesweeper.Model
{
    public class Cell
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
            HasBomb = true;
        }

        public void SetQuantityBombsNear(int quantityBombsNear)
        {
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
    }
}
