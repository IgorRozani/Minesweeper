namespace Minesweeper.Domain.Interface
{
    public interface IFieldLevel
    {
        int QuantityCollumns();
        int QuantityRows();
        int QuantiyBombs();
        int Size();
    }
}
