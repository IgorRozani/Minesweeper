using Minesweeper.Domain.Model;

namespace Minesweeper.Domain.Interface
{
    public interface IBombDirector
    {
        Cell[,] GenerateBombs(Cell[,] field, int quantityBombs);
    }
}
