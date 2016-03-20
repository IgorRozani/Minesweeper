using Minesweeper.Core.Interface;
using Minesweeper.Library.Extension;
using System.Linq;

namespace Minesweeper.Core.Builder
{
    public class NearBombCalculator : INearBombCalculator
    {
        public Cell[,] Calculate(Cell[,] field)
        {
            var lenghts = field.GetDimensionsLength();
            var rows = lenghts.FirstOrDefault();
            var collumns = lenghts.LastOrDefault();

            return field;
        }

        //private void CalculateQuantityNearBombs()
        //{
        //    for (var row = 0; row < _fieldLevel.QuantityRows(); row++)
        //    {
        //        for (var collumn = 0; collumn < _fieldLevel.QuantityCollumns(); collumn++)
        //        {
        //            var quantityBombsNear = 0;

        //            var rowsToCheck = new List<int> { row };
        //            if (row > 0)
        //                rowsToCheck.Add(row - 1);
        //            if (row + 1 < _fieldLevel.QuantityRows())
        //                rowsToCheck.Add(row + 1);

        //            foreach (var rowToCheck in rowsToCheck)
        //            {
        //                if (collumn > 0)
        //                    if (_field[rowToCheck][collumn - 1].HasBomb)
        //                        quantityBombsNear++;
        //                if (collumn + 1 < _fieldLevel.QuantityCollumns())
        //                    if (_field[rowToCheck][collumn + 1].HasBomb)
        //                        quantityBombsNear++;
        //            }

        //            _field[row][collumn].SetQuantityBombsNear(quantityBombsNear);
        //        }
        //    }
        //}
    }
}
