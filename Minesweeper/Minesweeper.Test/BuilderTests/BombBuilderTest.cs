using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Core.Builder;
using Minesweeper.Core.Interface;
using NSubstitute;

namespace Minesweeper.Test.BuilderTests
{
    [TestClass]
    public class BombBuilderTest
    {
        private const int QUANTITY_CELLS = 100;
        private const int QUANTITY_BOMBS = 20;

        private BombBuilder bombBuilder;
        private IFieldLevel mockFieldLevel;

        [TestInitialize]
        public void InitializeTests()
        {
            mockFieldLevel = Substitute.For<IFieldLevel>();
            mockFieldLevel.QuantityCells().Returns(QUANTITY_CELLS);
            mockFieldLevel.QuantiyBombs().Returns(QUANTITY_BOMBS);

            bombBuilder = new BombBuilder();
        }

        [TestMethod]
        public void BombBuilderGenerateTwentyBombs()
        {
            var bombs = bombBuilder.GenerateBombsPosition(mockFieldLevel);
            Assert.AreEqual(QUANTITY_BOMBS, bombs.Count);
        }

        [TestMethod]
        public void BombBuilderDontGenerateBombsInSamePosition()
        {
            var bombs = bombBuilder.GenerateBombsPosition(mockFieldLevel);
            CollectionAssert.AllItemsAreUnique(bombs);
        }
    }
}
