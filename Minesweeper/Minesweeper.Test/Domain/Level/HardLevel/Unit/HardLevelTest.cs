using FluentAssertions;
using NUnit.Framework;

namespace Minesweeper.Test.Domain.Level.HardLevel.Unit
{
    [TestFixture]
    public class HardLevelTest
    {
        private Minesweeper.Domain.Level.HardLevel _hardLevel;

        [SetUp]
        public void InitializeTests()
        {
            _hardLevel = new Minesweeper.Domain.Level.HardLevel();
        }

        [Test]
        public void QuantityRows_Return30()
        {
            var quantityRows = _hardLevel.QuantityRows();
            quantityRows.Should().Be(30);
        }

        [Test]
        public void QuantityCollumns_Return30()
        {
            var quantityCollumns = _hardLevel.QuantityCollumns();
            quantityCollumns.Should().Be(30);
        }
    }
}
