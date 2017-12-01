using Minesweeper.Domain.Extension;
using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Model;

namespace Minesweeper.Domain.Core.GameMechanic
{
    public class CellsOpener : ICellsOpener
    {
        private IIdentifyCellsAround _identifyCellsAround;
        private Cell[,] _field;

        public CellsOpener(IIdentifyCellsAround identifyCellsAround)
        {
            _identifyCellsAround = identifyCellsAround;
        }

        public void Check(Cell[,] field, Position position)
        {
            var cell = field.GetCell(position);

            if (cell.IsRevealed() || cell.IsFlagged())
                return;

            cell.Check();

            if (cell.QuantityBombsNear > 0)
                return;

            var positionsAround = _identifyCellsAround.Identify(field, position);

            foreach (var positionAround in positionsAround)
            {
                var currentCell = field.GetCell(positionAround);
                currentCell.Check();
                if (currentCell.QuantityBombsNear == 0)
                {
                    Check(field, positionAround);
                }
            }
        }
    }
}
