using Minesweeper.Domain.Interface;

namespace Minesweeper.Domain.Core.FieldBuilder
{
    public abstract class LevelBuilder : IFieldLevel
    {
        private const decimal BOMBS_PERCENT = 0.2m;

        public abstract int QuantityRows();

        public abstract int QuantityCollumns();

        public int QuantiyBombs() => (int)(Size() * BOMBS_PERCENT);

        public int Size() => QuantityRows() * QuantityCollumns();
    }
}
