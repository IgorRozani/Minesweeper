using Minesweeper.Domain.FieldBuilders;

namespace Minesweeper.Domain.Levels
{
    public class EasyLevel : LevelBuilder
    {
        public override int QuantityRows() => 10;

        public override int QuantityCollumns() => 10;
    }
}
