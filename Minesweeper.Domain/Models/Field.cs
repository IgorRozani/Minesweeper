using Minesweeper.Domain.Extensions;
using Minesweeper.Domain.Interfaces;

namespace Minesweeper.Domain.Models
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
            Cells.GetCell(position).Flag();
        }

        public void Unflag(Position position)
        {
            Cells.GetCell(position).Unflag();
        }
    }
}