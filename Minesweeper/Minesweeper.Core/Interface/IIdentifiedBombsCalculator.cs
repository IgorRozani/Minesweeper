using Minesweeper.Domain.Model;

namespace Minesweeper.Domain.Interface
{
    public interface IIdentifiedBombsCalculator
    {
        int Calculate(Cell[,] field, Position position);
    }
}
