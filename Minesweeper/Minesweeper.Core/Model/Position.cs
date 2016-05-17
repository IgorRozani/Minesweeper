namespace Minesweeper.Domain.Model
{
    public class Position
    {
        public Position(int row, int collumn)
        {
            Row = row;
            Collumn = collumn;
        }

        public int Row { get; private set; }
        public int Collumn { get; private set; }
    }
}
