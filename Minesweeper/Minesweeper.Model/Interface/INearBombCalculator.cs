namespace Minesweeper.Model.Interface
{
    public interface INearBombCalculator
    {
        Cell[,] Calculate(Cell[,] field);
    }
}
