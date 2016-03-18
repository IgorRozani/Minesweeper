using Minesweeper.Model.Interface;
using System.Collections.Generic;

namespace Minesweeper.Model.Builder
{
    public class FieldDirector
    {
        private IFieldLevel _fieldLevel;
        private IBombBuilder _bombBuilder;
        private INearBombCalculator _newBombCalculator;
        private Cell[,] _field;

        public FieldDirector(IFieldLevel fieldLevel)
        {
            _fieldLevel = fieldLevel;
            _bombBuilder = new BombBuilder();
            _newBombCalculator = new NearBombCalculator();
        }

        public Cell[,] CreateField()
        {
            InstanciateField();
            CreateBombs();

            return _field;
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
            PlaceBombsInField(_bombBuilder.GenerateBombsPosition(_fieldLevel));
            //CalculateQuantityNearBombs();
        }


        private void PlaceBombsInField(List<int> bombsPosition)
        {
            foreach (var bombPosition in bombsPosition)
            {
                if (bombPosition == 0)
                    _field[0, 0].SetBomb();
                else
                {
                    var row = bombPosition / _fieldLevel.QuantityCollumns();
                    var collumn = bombPosition % _fieldLevel.QuantityCollumns();
                    _field[row, collumn].SetBomb();
                }
            }
        }

        
    }
}
