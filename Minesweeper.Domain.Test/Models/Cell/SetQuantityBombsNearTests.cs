using Minesweeper.Domain.Exceptions;
using Xunit;

namespace Minesweeper.Domain.Test.Models.Cell
{
    public class SetQuantityBombsNearTests
    {
        private Domain.Models.Cell _cell;

        public SetQuantityBombsNearTests()
        {
            _cell = new Domain.Models.Cell();
        }

        [Fact(DisplayName = "Set 5 bombs return 5 bombs")]
        public void Set5BombsReturn5Bombs()
        {
            _cell.SetQuantityBombsNear(5);

            Assert.Equal(5, _cell.QuantityBombsNear);
        }

        [Fact(DisplayName = "In checked cell return MinesweeperException")]
        public void InCheckedCellReturnMinesweeperException()
        {
            _cell.Check();

            Assert.Throws<MinesweeperException>(() => _cell.SetQuantityBombsNear(4));
        }

        [Fact(DisplayName = "In checked cell return message in MinesweeperException")]
        public void InCheckedCellReturnMessageInMinesweeperException()
        {
            _cell.Check();

            var exception = Assert.Throws<MinesweeperException>(() => _cell.SetQuantityBombsNear(4));

            Assert.Equal("It can't be set quantity bombs near in a checked cell.", exception.Message);
        }
    }
}
