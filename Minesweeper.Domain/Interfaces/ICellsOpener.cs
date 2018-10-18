using Minesweeper.Domain.Models;

namespace Minesweeper.Domain.Interfaces
{
    public interface ICellsOpener
    {
        void Check(Cell[,] field, Position position);
    }
}