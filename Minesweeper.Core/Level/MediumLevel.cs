using Minesweeper.Domain.Core.FieldBuilder;

namespace Minesweeper.Domain.Level
{
    public class MediumLevel : LevelBuilder
    {
        public override int QuantityRows() => 20;

        public override int QuantityCollumns() => 20;
    }
}
