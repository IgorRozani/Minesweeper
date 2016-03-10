using Minesweeper.Model.Builder;
using Minesweeper.Model.Enumerator;
using Minesweeper.Model.Level;
using System;

namespace Minesweeper.Model
{
    public class Game
    {
        public DifficultyLevelEnum Difficulty { get; private set; }
        public Cell[][] Field { get; private set; }

        public void ConfigureGameDifficulty(DifficultyLevelEnum difficulty)
        {
            Difficulty = difficulty;
            Field = BuildField(difficulty);
        }

        private static Cell[][] BuildField(DifficultyLevelEnum difficulty)
        {
            FieldBuilder fieldBuilder;
            switch (difficulty)
            {
                case DifficultyLevelEnum.Easy:
                    fieldBuilder = new FieldBuilder(new EasyLevel());
                    break;
                case DifficultyLevelEnum.Medium:
                    fieldBuilder = new FieldBuilder(new MediumLevel());
                    break;
                case DifficultyLevelEnum.Hard:
                    fieldBuilder = new FieldBuilder(new HardLevel());
                    break;
                default:
                    throw new NotImplementedException();
            }
            return fieldBuilder.GetField();
        }
    }
}
