using Minesweeper.Model.Builder;

namespace Minesweeper.Model.Level
{
    public class EasyLevel : LevelBuilder
    {
        public override int QuantityCellX()
        {
            return 3;
        }

        public override int QuantityCellY()
        {
            return 3;
        }
    }
}
