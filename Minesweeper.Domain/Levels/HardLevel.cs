using Minesweeper.Domain.FieldBuilders;

namespace Minesweeper.Domain.Levels
{
    public class HardLevel : LevelBuilder
    {
        public override int QuantityRows() => 30;

        public override int QuantityCollumns() => 30;
    }
}