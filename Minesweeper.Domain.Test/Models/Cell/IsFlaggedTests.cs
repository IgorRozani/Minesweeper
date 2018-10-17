using Xunit;

namespace Minesweeper.Domain.Test.Models.Cell
{
    public class IsFlaggedTests
    {
        private readonly Domain.Models.Cell _cell;

        public IsFlaggedTests()
        {
            _cell = new Domain.Models.Cell();
        }

        [Fact(DisplayName = "Status flagged return true")]
        public void StatusFlaggedReturnTrue()
        {
            _cell.Flag();

            Assert.True(_cell.IsFlagged());
        }

        [Fact(DisplayName = "Status untouched return false")]
        public void StatusUntouchedReturnFalse()
        {
            Assert.False(_cell.IsFlagged());
        }

        [Fact(DisplayName = "Status revealed return false")]
        public void StatusRevealedReturnFalse()
        {
            _cell.Check();

            Assert.False(_cell.IsFlagged());
        }
    }
}
