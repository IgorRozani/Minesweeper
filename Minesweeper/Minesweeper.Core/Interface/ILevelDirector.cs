using Minesweeper.Core.Model;

namespace Minesweeper.Core.Interface
{
    public interface IFieldDirector
    {
        Field CreateField(Field field);
    }
}
