using Minesweeper.Model.Builder;

namespace Minesweeper.Model.Level
{
    public class HardLevel : LevelBuilder
    {
        public override int QuantityRows()
        {
            return 20;
        }

        public override int QuantityCollumns()
        {
            return 21;
        }
    }
}
