using Minesweeper.Domain.Model;

namespace Minesweeper.Test.Helper
{
    public static class FieldHelper
    {
        public static Cell[,] InstanciateField3X3()
        {
            var field = new Cell[3, 3];

            field[0, 0] = new Cell();
            field[0, 1] = new Cell();
            field[0, 2] = new Cell();

            field[1, 0] = new Cell();
            field[1, 1] = new Cell();
            field[1, 2] = new Cell();

            field[2, 0] = new Cell();
            field[2, 1] = new Cell();
            field[2, 2] = new Cell();

            return field;
        }
    }
}
