using Minesweeper.Core.Model;

namespace Minesweeper.Core.Interface
{
    public interface IBombDirector
    {
        Cell[,] GenerateBombs(Cell[,] field, int quantityBombs);
    }
}
