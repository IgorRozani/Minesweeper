using Minesweeper.Library.Exceptions;
using Minesweeper.Model.Enumerators;

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

        public void Configure(bool hasBomb, int quantityBombsNear)
        {
            QuantityBombsNear = quantityBombsNear;
            HasBomb = hasBomb;
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
