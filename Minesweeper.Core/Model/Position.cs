namespace Minesweeper.Domain.Model
{
    public class Position
    {
        public Position(int row, int collumn)
        {
            Row = row;
            Collumn = collumn;
        }

        public int Row { get; }
        public int Collumn { get; }
    }
}
