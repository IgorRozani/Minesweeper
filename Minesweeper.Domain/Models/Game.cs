using Minesweeper.Domain.Enums;
using Minesweeper.Domain.Exceptions;
using Minesweeper.Domain.Interfaces;
using Minesweeper.Domain.Levels;

namespace Minesweeper.Domain.Models
{
    public class Game
    {
        private ICellsOpener _cellsOpener;
        private IFieldDirector _fieldDirector;

        public DifficultyLevelEnum Difficulty { get; private set; }
        public Field Field { get; private set; }

        public Game(IFieldDirector fieldDirector, ICellsOpener cellsOpener)
        {
            _fieldDirector = fieldDirector;
            _cellsOpener = cellsOpener;
        }

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

            Field = new Field(_fieldDirector, _cellsOpener);

            Field.CreateField(fieldLevel);
        }
    }
}