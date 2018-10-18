using System.Collections.Generic;
using Minesweeper.Domain.Models;

namespace Minesweeper.Domain.Interfaces
{
    public interface IIdentifyCellsAround
    {
        List<Position> Identify(Cell[,] field, Position position);
    }
}