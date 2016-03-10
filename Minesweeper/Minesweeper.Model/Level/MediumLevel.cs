using Minesweeper.Model.Builder;

namespace Minesweeper.Model.Level
{
    public class MediumLevel : LevelBuilder
    {
        public override int QuantityCellX()
        {
            return 9;
        }

        public override int QuantityCellY()
        {
            return 9;
        }
    }
}
