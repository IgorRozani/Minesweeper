using Xunit;

namespace Minesweeper.Domain.Test.Models.Cell
{
    public class EqualsTests
    {
        private readonly Domain.Models.Cell _cell;

        public EqualsTests()
        {
            _cell= new Domain.Models.Cell();
        }

        [Fact(DisplayName = "Null object returns false")]
        public void NullObjectReturnFalse()
        {
            Assert.False(_cell.Equals(null));
        }

        [Fact(DisplayName = "With all fields similar return true")]
        public void WithAllFieldsSimilarReturnTrue()
        {
            var testCell = new Domain.Models.Cell();

            Assert.True(_cell.Equals(testCell));
        }

        [Fact(DisplayName = "With different status return false")]
        public void WithDifferentStatusReturnFalse()
        {
            var testCell = new Domain.Models.Cell();
            testCell.Check();

            Assert.False(_cell.Equals(testCell));
        }

        [Fact(DisplayName = "With different QuantityBombsNear return false")]
        public void WithDifferentQuantityBombsNearReturnFalse()
        {
            var testCell = new Domain.Models.Cell();
            testCell.SetQuantityBombsNear(3);

            Assert.False(_cell.Equals(testCell));
        }

        [Fact(DisplayName = "With different HasBomb return false")]
        public void WithDifferentHasBombReturnFalse()
        {
            var testCell = new Domain.Models.Cell();
            testCell.SetBomb();

            Assert.False(_cell.Equals(testCell));
        }
    }
}
