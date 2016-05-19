using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Model;
using System;
using System.Collections.Generic;

namespace Minesweeper.Domain.Core.Helper
{
    public class IdentifyCellsAround : IIdentifyCellsAround
    {
        public List<Position> Identify(Cell[,] field, Position position)
        {
            throw new NotImplementedException();
        }
    }
}
