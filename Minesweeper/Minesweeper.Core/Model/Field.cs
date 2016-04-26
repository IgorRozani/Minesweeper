using Minesweeper.Domain.Interface;

namespace Minesweeper.Domain.Model
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
