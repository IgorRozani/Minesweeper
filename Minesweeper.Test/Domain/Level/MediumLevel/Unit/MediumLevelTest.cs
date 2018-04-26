using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Minesweeper.Test.Domain.Level.MediumLevel.Unit
{
    [TestFixture]
    public class MediumLevelTest
    {
        private Minesweeper.Domain.Level.MediumLevel _mediumLevel;

        [SetUp]
        public void InitializeTests()
        {
            _mediumLevel = new Minesweeper.Domain.Level.MediumLevel();
        }

        [Test]
        public void MediumLevel_QuantityRows_Return20()
        {
            var quantityRows = _mediumLevel.QuantityRows();
            quantityRows.Should().Be(20);
        }

        [Test]
        public void MediumLevel_QuantityCollumns_Return20()
        {
            var quantityCollumns = _mediumLevel.QuantityCollumns();
            quantityCollumns.Should().Be(20);
        }
    }
}
