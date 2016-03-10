using Minesweeper.Model.Interface;

namespace Minesweeper.Model.Builder
{
    public abstract class LevelBuilder : IFieldLevel
    {
        public abstract int QuantityCellX();

        public abstract int QuantityCellY();

        public int QuantiyBombs()
        {
            return (int)((QuantityCellX() * QuantityCellY()) * 0.2);
        }
    }
}
