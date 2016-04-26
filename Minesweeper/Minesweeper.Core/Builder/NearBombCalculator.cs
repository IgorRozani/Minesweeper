using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Model;
using Minesweeper.Library.Extension;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper.Domain.Builder
{
    public class NearBombCalculator : INearBombCalculator
    {
        public Cell[,] Calculate(Cell[,] field)
        {
            var lenghts = field.GetDimensionsLength();
            var rows = lenghts.FirstOrDefault();
            var collumns = lenghts.LastOrDefault();

            for (var row = 0; row < rows; row++)
            {
                for (var collumn = 0; collumn < collumns; collumn++)
                {
                    var quantityBombsNear = 0;

                    var rowsToCheck = new List<int> { row };
                    if (row > 0)
                        rowsToCheck.Add(row - 1);
                    if (row + 1 < rows)
                        rowsToCheck.Add(row + 1);

                    foreach (var rowToCheck in rowsToCheck)
                    {
                        if (field[rowToCheck, collumn].HasBomb && rowToCheck != row)
                            quantityBombsNear++;
                        if (collumn > 0)
                            if (field[rowToCheck,collumn - 1].HasBomb)
                                quantityBombsNear++;
                        if (collumn + 1 < collumns)
                            if (field[rowToCheck,collumn + 1].HasBomb)
                                quantityBombsNear++;
                    }

                    field[row,collumn].SetQuantityBombsNear(quantityBombsNear);
                }
            }

            return field;
        }
    }
}
