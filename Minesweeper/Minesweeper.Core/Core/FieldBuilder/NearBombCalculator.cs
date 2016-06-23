using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Model;
using Minesweeper.Domain.Extension;
using System.Linq;

namespace Minesweeper.Domain.Core.FieldBuilder
{
    public class NearBombCalculator : INearBombCalculator
    {
        private IIdentifyCellsAround identifyCellsAround;
        private Cell[,] field;

        public NearBombCalculator(IIdentifyCellsAround identifyCellsAround)
        {
            this.identifyCellsAround = identifyCellsAround;
        }

        public Cell[,] Calculate(Cell[,] field)
        {
            this.field = field;

            var lenghts = field.GetDimensionsLength();
            var rows = lenghts.FirstOrDefault();
            var collumns = lenghts.LastOrDefault();

            for (var row = 0; row < rows; row++)
            {
                for (var collumn = 0; collumn < collumns; collumn++)
                {
                    var currentPosition = new Position(row, collumn);
                    field[row, collumn].SetQuantityBombsNear(QuantityBombsAround(currentPosition));
                }
            }

            return field;
        }

        private int QuantityBombsAround(Position position)
        {
            var quantityBombsNear = 0;

            var positionsAround = identifyCellsAround.Identify(field, position);

            foreach (var positionAround in positionsAround)
            {
                if (field[positionAround.Row, positionAround.Collumn].HasBomb)
                    quantityBombsNear++;
            }
            return quantityBombsNear;
        }

    }
}
