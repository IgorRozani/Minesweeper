using Minesweeper.Domain.Model;
using System.Collections.Generic;

namespace Minesweeper.Domain.Interface
{
    public interface IIdentifyCellsAround
    {
        List<Position> Identify(Cell[,] field, Position position);
    }
}
