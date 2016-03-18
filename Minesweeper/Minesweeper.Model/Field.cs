using Minesweeper.Model.Builder;
using Minesweeper.Model.Interface;

namespace Minesweeper.Model
{
    public class Field
    {
        public Field(IFieldLevel fieldLevel)
        {
            _fieldLevel = fieldLevel;
            var fieldBuilder = new FieldDirector(fieldLevel);
            Cells = fieldBuilder.CreateField();
        }

        public Cell[,] Cells { get; private set; }
        private IFieldLevel _fieldLevel;
    }
}
