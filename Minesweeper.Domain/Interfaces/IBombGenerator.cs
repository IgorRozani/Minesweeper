using System.Collections.Generic;
using Minesweeper.Domain.Models;

namespace Minesweeper.Domain.Interfaces
{
    public interface IBombGenerator
    {
        List<Position> GenerateBombsPosition(int quantityBombs, int fieldSize, int quantityCollumns);
    }
}