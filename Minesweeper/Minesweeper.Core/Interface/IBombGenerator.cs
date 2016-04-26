using System.Collections.Generic;

namespace Minesweeper.Domain.Interface
{
    public interface IBombGenerator
    {
        List<int> GenerateBombsPosition(int quantityBombs, int fieldSize);
    }
}
