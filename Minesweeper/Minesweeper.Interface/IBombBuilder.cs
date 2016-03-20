using System.Collections.Generic;

namespace Minesweeper.Interface
{
    public interface IBombBuilder
    {
        List<int> GenerateBombsPosition(IFieldLevel fieldLevel);
    }
}
