using Minesweeper.Model.Builder;

namespace Minesweeper.Model.Level
{
    public class EasyLevel : LevelBuilder
    {
        public override int QuantityRows()
        {
            return 3;
        }

        public override int QuantityCollumns()
        {
            return 3;
        }
    }
}
