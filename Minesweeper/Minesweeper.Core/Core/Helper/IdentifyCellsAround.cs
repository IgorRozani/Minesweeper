using Minesweeper.Domain.Model;
using Minesweeper.Library.Extension;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper.Domain.Core.Helper
{
    public class IdentifyCellsAround
    {
        private Cell[,] field;
        private Position position;
        private int quantityFieldRows, quantityFieldCollumns;
        private List<Position> positionsAround;

        public List<Position> Identify(Cell[,] field, Position position)
        {
            InstanciateObjects(field, position);

            IdentifyPositions();

            return positionsAround;
        }

        private void InstanciateObjects(Cell[,] field, Position position)
        {
            this.position = position;
            this.field = field;

            GetDimesionsFromField();

            positionsAround = new List<Position>();
        }

        private void GetDimesionsFromField()
        {
            var lenghts = field.GetDimensionsLength();
            quantityFieldRows = lenghts.FirstOrDefault();
            quantityFieldCollumns = lenghts.LastOrDefault();
        }

        private void IdentifyPositions()
        {
            if (position.Row > 0)
                GetPositionsAroundInRow(position.Row - 1);

            GetPositionsAroundInRow(position.Row);

            if (quantityFieldRows - 1 > position.Row)
                GetPositionsAroundInRow(position.Row + 1);
        }

        private void GetPositionsAroundInRow(int row)
        {
            if (position.Collumn > 0)
                positionsAround.Add(new Position(row, position.Collumn - 1));
            if (position.Row != row)
                positionsAround.Add(new Position(row, position.Collumn));
            if (quantityFieldCollumns - 1 > position.Collumn)
                positionsAround.Add(new Position(row, position.Collumn + 1));
        }
    }
}
