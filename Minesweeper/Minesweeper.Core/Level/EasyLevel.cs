using Minesweeper.Core.Builder;

namespace Minesweeper.Core.Level
{
    public class EasyLevel : LevelBuilder
    {
        public override int QuantityRows()
        {
            return 10;
        }

        public override int QuantityCollumns()
        {
            return 10;
        }
    }
}
