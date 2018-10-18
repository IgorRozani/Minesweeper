using Minesweeper.Domain.Models;

namespace Minesweeper.Domain.Interfaces
{
    public interface IBombDirector
    {
        Cell[,] GenerateBombs(Cell[,] field, int quantityBombs);
    }
}
