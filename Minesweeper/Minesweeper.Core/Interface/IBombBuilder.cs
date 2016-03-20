using System.Collections.Generic;

namespace Minesweeper.Core.Interface
{
    public interface IBombBuilder
    {
        List<int> GenerateBombsPosition(IFieldLevel fieldLevel);
    }
}
