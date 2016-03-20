using Minesweeper.Model;

namespace Minesweeper.Interface
{
    public interface INearBombCalculator
    {
        Cell[,] Calculate(Cell[,] field);
    }
}
