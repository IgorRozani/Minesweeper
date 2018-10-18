using Minesweeper.Domain.FieldBuilders;

namespace Minesweeper.Domain.Levels
{
    public class MediumLevel : LevelBuilder
    {
        public override int QuantityRows() => 20;

        public override int QuantityCollumns() => 20;
    }
}