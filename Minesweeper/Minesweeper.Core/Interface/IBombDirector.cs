using System.Collections.Generic;

namespace Minesweeper.Core.Interface
{
    public interface IBombDirector
    {
        Cell[,] GenerateBombs(Cell[,] field, int quantityBombs);
    }
}
