namespace Minesweeper.Domain.Interfaces
{
    public interface IFieldLevel
    {
        int QuantityCollumns();
        int QuantityRows();
        int QuantiyBombs();
        int Size();
    }
}