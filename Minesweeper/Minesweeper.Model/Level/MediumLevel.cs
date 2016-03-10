using Minesweeper.Model.Builder;

namespace Minesweeper.Model.Level
{
    public class MediumLevel : LevelBuilder
    {
        public override int QuantityRows()
        {
            return 9;
        }

        public override int QuantityCollumns()
        {
            return 9;
        }
    }
}
