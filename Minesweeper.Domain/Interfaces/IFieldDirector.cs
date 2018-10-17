using Minesweeper.Domain.Models;

namespace Minesweeper.Domain.Interfaces
{
    public interface IFieldDirector
    {
        Cell[,] CreateField(IFieldLevel fieldLevel);
    }
}