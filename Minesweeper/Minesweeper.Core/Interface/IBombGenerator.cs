using System.Collections.Generic;

namespace Minesweeper.Core.Interface
{
    public interface IBombGenerator
    {
        List<int> GenerateBombsPosition(int quantityBombs, int fieldSize);
    }
}
