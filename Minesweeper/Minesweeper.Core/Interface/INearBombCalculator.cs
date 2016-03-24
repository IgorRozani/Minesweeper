using Minesweeper.Core.Model;

namespace Minesweeper.Core.Interface
{
    public interface INearBombCalculator
    {
        Cell[,] Calculate(Cell[,] field);
    }
}
