using Minesweeper.Model.Builder;
using Minesweeper.Model.Enumerator;
using Minesweeper.Model.Level;

namespace Minesweeper.Model
{
    public class Game
    {
        public DifficultyLevelEnum Difficulty { get; private set; }
        public FieldBuilder FieldBuilder { get; private set; }

        public void ConfigureGameDifficulty(DifficultyLevelEnum difficulty)
        {
            Difficulty = difficulty;
            switch (Difficulty)
            {
                case DifficultyLevelEnum.Easy:
                    FieldBuilder = new FieldBuilder(new EasyLevel());
                    break;
                case DifficultyLevelEnum.Medium:
                    FieldBuilder = new FieldBuilder(new MediumLevel());
                    break;
                case DifficultyLevelEnum.Hard:
                    FieldBuilder = new FieldBuilder(new HardLevel());
                    break;
            }
        }
    }
}
