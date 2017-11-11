using Minesweeper.Domain.Model;

namespace Minesweeper.Domain.Interface
{
    public interface IFieldDirector
    {
        Cell[,] CreateField(IFieldLevel fieldLevel);
    }
}
