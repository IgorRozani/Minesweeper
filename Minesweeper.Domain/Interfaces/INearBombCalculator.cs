using Minesweeper.Domain.Models;

namespace Minesweeper.Domain.Interfaces
{
    public interface INearBombCalculator
    {
        Cell[,] Calculate(Cell[,] field);
    }
}