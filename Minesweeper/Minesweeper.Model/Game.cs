using Minesweeper.Model.Enumerator;
using Minesweeper.Model.Interface;
using Minesweeper.Model.Level;
using System;

namespace Minesweeper.Model
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
                    throw new NotImplementedException();
            }
            Field = new Field(fieldLevel);
        }
    }
}
