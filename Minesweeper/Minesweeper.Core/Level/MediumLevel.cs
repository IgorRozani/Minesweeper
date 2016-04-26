using Minesweeper.Domain.Builder;

namespace Minesweeper.Domain.Level
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
