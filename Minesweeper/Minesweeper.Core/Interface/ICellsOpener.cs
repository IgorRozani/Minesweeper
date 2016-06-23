using Minesweeper.Domain.Model;

namespace Minesweeper.Domain.Interface
{
    public interface ICellsOpener
    {
        Cell[,] Check(Cell[,] field, Position position);
    }
}
