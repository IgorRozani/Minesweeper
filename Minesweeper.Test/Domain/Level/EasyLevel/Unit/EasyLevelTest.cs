using FluentAssertions;
using NUnit.Framework;

namespace Minesweeper.Test.Domain.Level.EasyLevel.Unit
{
    [TestFixture]
    public class EasyLevelTest
    {
        private Minesweeper.Domain.Level.EasyLevel _easyLevel;

        [SetUp]
        public void InitializeTests()
        {
            _easyLevel = new Minesweeper.Domain.Level.EasyLevel();
        }

        [Test]
        public void QuantityRows_Return10()
        {
            var quantityRows = _easyLevel.QuantityRows();
            quantityRows.Should().Be(10);
        }

        [Test]
        public void QuantityCollumns_Return10()
        {
            var quantityCollumns = _easyLevel.QuantityCollumns();
            quantityCollumns.Should().Be(10);
        }
    }
}
