using System.Collections.Generic;

namespace Minesweeper.Model
{
    public class Field
    {
        public Dictionary<string, List<Cell>> Cells { get; private set; }
    }
}
