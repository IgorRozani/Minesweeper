using System.Collections.Generic;

namespace Minesweeper.Model.Interface
{
    public interface IBombBuilder
    {
        List<int> GenerateBombsPosition(IFieldLevel fieldLevel);
    }
}
