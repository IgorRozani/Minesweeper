using Minesweeper.Domain.Builder;
using Minesweeper.Domain.Interface;

namespace Minesweeper.Domain.Model
{
    public class Field
    {
        public Field(IFieldLevel fieldLevel)
        {
            FieldLevel = fieldLevel;
            CreateField();
        }

        public Cell[,] Cells { get; private set; }
        public IFieldLevel FieldLevel { get; private set; }

        private void CreateField()
        {
            IBombGenerator bombGenerator = new BombGenerator();
            IBombDirector bombDirector = new BombDirector(bombGenerator);
            INearBombCalculator nearBombCalculator = new NearBombCalculator();
            IFieldDirector fieldDirector = new FieldDirector(bombDirector, nearBombCalculator);
            Cells = fieldDirector.CreateField(FieldLevel);
        }

        public void Check(Position position)
        {
            Cells[position.Row, position.Collumn].Check();
        }

        public void Flag(Position position)
        {
            Cells[position.Row, position.Collumn].Flag();
        }
    }
}
