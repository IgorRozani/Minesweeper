using Minesweeper.Core.Builder;

namespace Minesweeper.Core.Level
{
    public class MediumLevel : LevelBuilder
    {
        public override int QuantityRows()
        {
            return 20;
        }

        public override int QuantityCollumns()
        {
            return 20;
        }
    }
}
