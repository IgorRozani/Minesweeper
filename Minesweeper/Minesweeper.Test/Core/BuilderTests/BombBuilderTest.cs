using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Core.Builder;
using Minesweeper.Library.Exception;

namespace Minesweeper.Test.Core.BuilderTests
{
    [TestClass]
    public class BombGeneratorTest
    {
        private const int FIELD_SIZE = 100;
        private const int FIELD_SIZE_SMALL = 10;
        private const int QUANTITY_BOMBS = 20;
        private const int QUANTITY_ZERO_BOMBS = 0;

        private BombGenerator bombGenerator;

        [TestInitialize]
        public void InitializeTests()
        {
            bombGenerator = new BombGenerator();
        }

        [TestMethod]
        public void BombGeneratorGenerateTwentyBombs()
        {
            var bombs = bombGenerator.GenerateBombsPosition(QUANTITY_BOMBS, FIELD_SIZE);
            Assert.AreEqual(QUANTITY_BOMBS, bombs.Count);
        }

        [TestMethod]
        public void BombGeneratorDontGenerateBombsInSamePosition()
        {
            var bombs = bombGenerator.GenerateBombsPosition(QUANTITY_BOMBS, FIELD_SIZE);
            CollectionAssert.AllItemsAreUnique(bombs);
        }

        [TestMethod]
        public void BombGeneratorGenerateZeroBombs()
        {
            var bombs = bombGenerator.GenerateBombsPosition(QUANTITY_ZERO_BOMBS, FIELD_SIZE);
            Assert.AreEqual(QUANTITY_ZERO_BOMBS, bombs.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(MinesweeperException))]
        public void BombGeneratorTryGenerateMoreBombsThanFieldSize()
        {
            var bombs = bombGenerator.GenerateBombsPosition(QUANTITY_BOMBS, FIELD_SIZE_SMALL);
        }
    }
}
