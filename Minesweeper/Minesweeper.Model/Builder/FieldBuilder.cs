using Minesweeper.Model.Interface;
using System;

namespace Minesweeper.Model.Builder
{
    public class FieldBuilder
    {
        private IFieldLevel _fieldLevel;
        private Cell[][] _field;

        public FieldBuilder(IFieldLevel fieldLevel)
        {
            _fieldLevel = fieldLevel;
            CreateField();
        }

        private void CreateField()
        {
            InstanciateField();
            CreateBombs();
        }

        private void InstanciateField()
        {
            var quantityCellX = _fieldLevel.QuantityCellX();
            _field = new Cell[_fieldLevel.QuantityCellX()][];
            for (var row = 0; row < _fieldLevel.QuantityCellX(); row++)
            {
                _field[row] = CreateRow();
            }
        }

        private Cell[] CreateRow()
        {
            var quantityCellY = _fieldLevel.QuantityCellY();
            var row = new Cell[quantityCellY];
            for (var cell = 0; cell < quantityCellY; cell++)
            {
                row[cell] = new Cell();
            }
            return row;
        }

        private void CreateBombs()
        {
            var quantity = _fieldLevel.QuantiyBombs();
            throw new NotImplementedException();
        }

        public Cell[][] GetField()
        {
            return _field;
        }
    }
}
