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
            var quantityRows = _fieldLevel.QuantityRows();
            _field = new Cell[quantityRows][];
            for (var row = 0; row < quantityRows; row++)
            {
                _field[row] = CreateRow();
            }
        }

        private Cell[] CreateRow()
        {
            var quantityCollumns = _fieldLevel.QuantityCollumns();
            var row = new Cell[quantityCollumns];
            for (var cell = 0; cell < quantityCollumns; cell++)
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
