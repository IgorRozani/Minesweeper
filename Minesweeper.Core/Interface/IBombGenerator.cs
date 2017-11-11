using Minesweeper.Domain.Model;
using System.Collections.Generic;

namespace Minesweeper.Domain.Interface
{
    public interface IBombGenerator
    {
        List<Position> GenerateBombsPosition(int quantityBombs, int fieldSize, int quantityCollumns);
    }
}
