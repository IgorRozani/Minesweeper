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

        public void Check(int row, int collumn)
        {
            Cells[row, collumn].Check();
        }

        public void Flag(int row,int collumn)
        {
            Cells[row, collumn].Flag();
        }
    }
}
