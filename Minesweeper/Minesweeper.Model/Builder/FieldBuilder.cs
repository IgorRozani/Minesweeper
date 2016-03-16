using Minesweeper.Model.Interface;
using System;
using System.Collections.Generic;

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
            var bombsPosition = GenerateBombsPosition();
            PlaceBombsInField(bombsPosition);
            CalculateQuantityNearBombs();
        }

        private List<int> GenerateBombsPosition()
        {
            var quantityBombs = _fieldLevel.QuantiyBombs();
            var fieldSize = _fieldLevel.QuantityRows() * _fieldLevel.QuantityCollumns();

            var bombsPosition = new List<int>();

            var generateMoreBomb = true;
            var random = new Random();
            while (generateMoreBomb)
            {
                var nextPosition = random.Next(0, fieldSize - 1);
                if (!bombsPosition.Contains(nextPosition))
                    bombsPosition.Add(nextPosition);

                generateMoreBomb = bombsPosition.Count == quantityBombs;
            }

            return bombsPosition;
        }

        private void PlaceBombsInField(List<int> bombsPosition)
        {
            foreach (var bombPosition in bombsPosition)
            {
                if (bombPosition == 0)
                    _field[0][0].SetBomb();
                else
                {
                    var row = bombPosition / _fieldLevel.QuantityCollumns();
                    var collumn = bombPosition % _fieldLevel.QuantityCollumns();
                    _field[row][collumn].SetBomb();
                }
            }
        }

        private void CalculateQuantityNearBombs()
        {
            for(var row = 0; row < _fieldLevel.QuantityRows(); row++)
            {
                for(var collumn = 0; collumn < _fieldLevel.QuantityCollumns(); collumn++)
                {
                    var quantityBombsNear = 0;

                    var rowsToCheck = new List<int> { row };
                    if (row > 0)
                        rowsToCheck.Add(row - 1);
                    if (row + 1 < _fieldLevel.QuantityRows())
                        rowsToCheck.Add(row + 1);

                    foreach(var rowToCheck in rowsToCheck)
                    {
                        if (collumn > 0)
                            if (_field[rowToCheck][collumn - 1].HasBomb)
                                quantityBombsNear++;
                        if (collumn + 1 < _fieldLevel.QuantityCollumns())
                            if (_field[rowToCheck][collumn + 1].HasBomb)
                                quantityBombsNear++;
                    }

                    _field[row][collumn].SetQuantityBombsNear(quantityBombsNear);
                }
            }
        }

        public Cell[][] GetField()
        {
            return _field;
        }
    }
}
