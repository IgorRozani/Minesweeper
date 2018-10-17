using Minesweeper.Domain.Enums;
using Minesweeper.Domain.Exceptions;
using Xunit;

namespace Minesweeper.Domain.Test.Models.Cell
{
    public class FlagTests
    {
        private Domain.Models.Cell _cell;

        public FlagTests()
        {
            _cell = new Domain.Models.Cell();
        }

        [Fact(DisplayName = "Cell with status untouched return flagged status")]
        public void CellWithStatusUntouchedReturnFlaggedStatus()
        {
            _cell.Flag();

            Assert.Equal(StatusEnum.Flagged, _cell.Status);
        }

        [Fact(DisplayName = "Cell with status revealed return MinesweeperException")]
        public void CellWithStatusRevealedReturnMinesweeperException()
        {
            _cell.Check();

            Assert.Throws<MinesweeperException>(() => _cell.Flag());
        }

        [Fact(DisplayName = "Cell with status revealed return message in MinesweeperException")]
        public void CellWithStatusRevealedReturnMessageInMinesweeperException()
        {
            _cell.Check();

           var exception = Assert.Throws<MinesweeperException>(() => _cell.Flag());

            Assert.Equal("This cell is already revealed.", exception.Message);
        }

        [Fact(DisplayName = "Cell with bomb return flagged status")]
        public void CellWithBombReturnFlaggedStatus()
        {
            _cell.SetBomb();

            _cell.Flag();

            Assert.Equal(StatusEnum.Flagged, _cell.Status);
        }

        [Fact(DisplayName = "Cell with status flagged return flagged status")]
        public void CellWithStatusFlaggedReturnFlaggedStatus()
        {
            _cell.Flag();

            _cell.Flag();

            Assert.Equal(StatusEnum.Flagged, _cell.Status);
        }
    }
}
