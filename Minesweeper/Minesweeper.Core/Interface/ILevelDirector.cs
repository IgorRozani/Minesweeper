using Minesweeper.Domain.Model;

namespace Minesweeper.Domain.Interface
{
    public interface IFieldDirector
    {
        Field CreateField(Field field);
    }
}
