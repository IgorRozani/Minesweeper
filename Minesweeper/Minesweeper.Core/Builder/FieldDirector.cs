using Minesweeper.Core.Interface;
using Minesweeper.Core.Model;

namespace Minesweeper.Core.Builder
{
    public class FieldDirector : IFieldDirector
    {
        private IBombDirector _bombDirector;
        private INearBombCalculator _nearBombCalculator;
        private Field _field;

        public FieldDirector(IBombDirector bombDirector, INearBombCalculator nearBombCalculator)
        {
            _bombDirector = bombDirector;
            _nearBombCalculator = nearBombCalculator;
        }

        public Field CreateField(Field field)
        {
            _field = field;

            InstanciateField();
            CreateBombs();

            return _field;
        }

        private void InstanciateField()
        {
            var rows = _field.FieldLevel.QuantityRows();

            _field.Cells = new Cell[rows, _field.FieldLevel.QuantityCollumns()];
            for (var row = 0; row < rows; row++)
                CreateRow(row);
        }

        private void CreateRow(int row)
        {
            var collumns = _field.FieldLevel.QuantityCollumns();
            for (var cell = 0; cell < collumns; cell++)
                _field.Cells[row, cell] = new Cell();
        }

        private void CreateBombs()
        {
            _field.Cells = _bombDirector.GenerateBombs(_field.Cells, _field.FieldLevel.QuantiyBombs());
        }
    }
}
