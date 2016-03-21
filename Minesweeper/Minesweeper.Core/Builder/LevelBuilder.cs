using Minesweeper.Core.Interface;

namespace Minesweeper.Core.Builder
{
    public abstract class LevelBuilder : IFieldLevel
    {
        private const decimal BOMBS_PERCENT = 0.2m;

        public abstract int QuantityRows();

        public abstract int QuantityCollumns();

        public int QuantiyBombs()
        {
            return (int)(Size() * BOMBS_PERCENT);
        }

        public int Size()
        {
            return QuantityRows() * QuantityCollumns();
        }
    }
}
