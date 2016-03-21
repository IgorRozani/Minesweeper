using Minesweeper.Core.Interface;

namespace Minesweeper.Core
{
    public class Field
    {
        public Field(IFieldLevel fieldLevel)
        {
            FieldLevel = fieldLevel;
        }

        public Cell[,] Cells { get; set; }
        public IFieldLevel FieldLevel { get; private set; }
    }
}
