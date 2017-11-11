using Minesweeper.Domain.Model;

namespace Minesweeper.Domain.Interface
{
    public interface INearBombCalculator
    {
        Cell[,] Calculate(Cell[,] field);
    }
}
