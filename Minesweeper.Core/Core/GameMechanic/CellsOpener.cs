using Minesweeper.Domain.Extension;
using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Model;
using System;

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

        public Cell[,] Check(Cell[,] field, Position position)
        {
            var cell = field.GetCell(position);
            var positionsAround = _identifyCellsAround.Identify(field, position);

            throw new NotImplementedException();
        }

        //private int QuantityFieldsAndFlagsAround(List<Position> positionsAround)
        //{
        //    var quantity = 0;
        //    foreach (var position in positionsAround)
        //    {
        //        if (fields)
        //    }
        //}


    }
}
