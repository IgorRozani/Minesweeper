using Minesweeper.Domain.Model;

namespace Minesweeper.Domain.Interface
{
    public interface ICellsOpener
    {
        void Check(Cell[,] field, Position position);
    }
}
