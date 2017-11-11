using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Model;

namespace Minesweeper.Domain.Core.FieldBuilder
{
    public class FieldDirector : IFieldDirector
    {
        private IBombDirector _bombDirector;
        private INearBombCalculator _nearBombCalculator;
        private IFieldLevel _fieldLevel;
        private Cell[,] _field;

        public FieldDirector(IBombDirector bombDirector, INearBombCalculator nearBombCalculator)
        {
            _bombDirector = bombDirector;
            _nearBombCalculator = nearBombCalculator;
        }

        public Cell[,] CreateField(IFieldLevel fieldLevel)
        {
            _fieldLevel = fieldLevel;

            InstanciateField();
            CreateBombs();
            CalculateNearBombs();

            return _field;
        }

        private void CalculateNearBombs()
        {
            _field = _nearBombCalculator.Calculate(_field);
        }

        private void InstanciateField()
        {
            var rows = _fieldLevel.QuantityRows();

            _field = new Cell[rows, _fieldLevel.QuantityCollumns()];
            for (var row = 0; row < rows; row++)
                CreateRow(row);
        }

        private void CreateRow(int row)
        {
            var collumns = _fieldLevel.QuantityCollumns();
            for (var cell = 0; cell < collumns; cell++)
                _field[row, cell] = new Cell();
        }

        private void CreateBombs()
        {
            _field = _bombDirector.GenerateBombs(_field, _fieldLevel.QuantiyBombs());
        }
    }
}
