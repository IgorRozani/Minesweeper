using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Model;
using Minesweeper.Domain.Extension;
using System.Linq;

namespace Minesweeper.Domain.Core.FieldBuilder
{
    public class NearBombCalculator : INearBombCalculator
    {
        private IIdentifyCellsAround _identifyCellsAround;
        private Cell[,] _field;

        public NearBombCalculator(IIdentifyCellsAround identifyCellsAround)
        {
            _identifyCellsAround = identifyCellsAround;
        }

        public Cell[,] Calculate(Cell[,] field)
        {
            _field = field;

            var lenghts = field.GetDimensionsLength();
            var rows = lenghts.FirstOrDefault();
            var collumns = lenghts.LastOrDefault();

            for (var row = 0; row < rows; row++)
            {
                for (var collumn = 0; collumn < collumns; collumn++)
                {
                    var currentPosition = new Position(row, collumn);
                    field.GetCell(currentPosition).SetQuantityBombsNear(QuantityBombsAround(currentPosition));
                }
            }

            return field;
        }

        private int QuantityBombsAround(Position position)
        {
            var quantityBombsNear = 0;

            var positionsAround = _identifyCellsAround.Identify(_field, position);

            foreach (var positionAround in positionsAround)
            {
                if (_field.GetCell(positionAround).HasBomb)
                    quantityBombsNear++;
            }
            return quantityBombsNear;
        }

    }
}
