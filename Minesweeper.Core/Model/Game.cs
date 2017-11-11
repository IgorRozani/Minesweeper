using Minesweeper.Domain.Enumerator;
using Minesweeper.Domain.Exception;
using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Level;

namespace Minesweeper.Domain.Model
{
    public class Game
    {
        public DifficultyLevelEnum Difficulty { get; private set; }
        public Field Field { get; private set; }

        public void ConfigureGameDifficulty(DifficultyLevelEnum difficulty)
        {
            Difficulty = difficulty;
            BuildField(difficulty);
        }

        private void BuildField(DifficultyLevelEnum difficulty)
        {
            IFieldLevel fieldLevel;
            switch (difficulty)
            {
                case DifficultyLevelEnum.Easy:
                    fieldLevel = new EasyLevel();
                    break;
                case DifficultyLevelEnum.Medium:
                    fieldLevel = new MediumLevel();
                    break;
                case DifficultyLevelEnum.Hard:
                    fieldLevel = new HardLevel();
                    break;
                default:
                    throw new MinesweeperException(Properties.Resources.InvalidGameLevel);
            }
            Field = new Field(fieldLevel);
        }
    }
}
