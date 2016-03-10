using Minesweeper.Model.Interface;

namespace Minesweeper.Model.Builder
{
    public abstract class LevelBuilder : IFieldLevel
    {
        public abstract int QuantityRows();

        public abstract int QuantityCollumns();

        public int QuantiyBombs()
        {
            return (int)((QuantityRows() * QuantityCollumns()) * 0.2);
        }
    }
}
