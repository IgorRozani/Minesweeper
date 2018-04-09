using Minesweeper.Domain.Interface;

namespace Minesweeper.Domain.Model
{
    public class Field
    {
        public Field(IFieldDirector fieldDirector, ICellsOpener cellsOpener)
        {
            _fieldDirector = fieldDirector;
            _cellsOpener = cellsOpener;
        }

        public Cell[,] Cells { get; private set; }
        public IFieldLevel FieldLevel { get; private set; }
        private ICellsOpener _cellsOpener;
        private IFieldDirector _fieldDirector;

        public void CreateField(IFieldLevel fieldLevel)
        {
            FieldLevel = fieldLevel;
            Cells = _fieldDirector.CreateField(FieldLevel);
        }

        public void Check(Position position)
        {
            _cellsOpener.Check(Cells, position);
        }

        public void Flag(Position position)
        {
            GetCell(position).Flag();
        }

        public void Unflag(Position position)
        {
            GetCell(position).Unflag();
        }

        public Cell GetCell(Position position)
        {
            return Cells[position.Row, position.Collumn];
        }
    }
}
