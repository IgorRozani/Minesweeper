using Minesweeper.Domain.Core.FieldBuilder;

namespace Minesweeper.Domain.Level
{
    public class HardLevel : LevelBuilder
    {
        public override int QuantityRows()
        {
            return 30;
        }

        public override int QuantityCollumns()
        {
            return 30;
        }
    }
}
