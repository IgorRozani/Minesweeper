using Minesweeper.Domain.Enums;
using Minesweeper.Domain.Exceptions;
using Xunit;

namespace Minesweeper.Domain.Test.Models.Cell
{
    public class UnflagTests
    {
        private Domain.Models.Cell _cell;

        public UnflagTests()
        {
            _cell = new Domain.Models.Cell();
        }

        [Fact(DisplayName = "Flagged cell return status untouched")]
        public void FlaggedCellReturnStatusUntouched()
        {
            _cell.Flag();

            _cell.Unflag();

            Assert.Equal(StatusEnum.Untouched, _cell.Status);
        }

        [Fact(DisplayName = "Cell without flag return MinesweeperException")]
        public void CellWithoutFlagReturnMinesweeperException()
        {
            Assert.Throws<MinesweeperException>(() => _cell.Unflag());
        }

        [Fact(DisplayName = "Cell without flag return message in MinesweeperException")]
        public void CellWithoutFlagReturnMessageInMinesweeperException()
        {
           var exception = Assert.Throws<MinesweeperException>(() => _cell.Unflag());

            Assert.Equal("It can't be unflag a cell without flag.", exception.Message);
        }

        [Fact(DisplayName = "Cell with status revelead return MinesweeperException")]
        public void CellWithStatusReveleadReturnMinesweeperException()
        {
            _cell.Check();

            Assert.Throws<MinesweeperException>(() => _cell.Unflag());
        }

        [Fact(DisplayName = "Cell with status revelead return message in MinesweeperException")]
        public void CellWithStatusReveleadReturnMessageInMinesweeperException()
        {
            _cell.Check();

            var exception = Assert.Throws<MinesweeperException>(() => _cell.Unflag());

            Assert.Equal("It can't be unflag a cell without flag.", exception.Message);
        }
    }
}
