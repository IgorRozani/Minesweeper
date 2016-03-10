using Minesweeper.Model.Builder;

namespace Minesweeper.Model.Level
{
    public class HardLevel : LevelBuilder
    {
        public override int QuantityCellX()
        {
            return 20;
        }

        public override int QuantityCellY()
        {
            return 21;
        }
    }
}
