using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Library.Exception;
using Minesweeper.Core;
using Minesweeper.Core.Enumerator;

namespace Minesweeper.Test.ModelTests
{
    [TestClass]
    public class CellTest
    {
        private Cell cell;

        [TestInitialize]
        public void Initialize()
        {
            cell = new Cell();
        }

        [TestMethod]
        public void CheckUntouchedCell()
        {
            Assert.AreEqual(cell.Status, StatusEnum.Untouched);
        }

        [TestMethod]
        public void ConfigureCellWithBomb()
        {
            cell.SetBomb();
            Assert.IsTrue(cell.HasBomb);
        }

        public void ConfigureCellWithoutBomb()
        {
            Assert.IsFalse(cell.HasBomb);
        }

        [TestMethod]
        public void ConfigureCellWith5BombsNear()
        {
            cell.SetQuantityBombsNear(5);
            Assert.AreEqual(cell.QuantityBombsNear, 5);
        }

        [TestMethod]
        public void FlagCell()
        {
            cell.Flagged();
            Assert.AreEqual(cell.Status, StatusEnum.Flagged);
        }

        [TestMethod]
        public void CheckCellWithoutBomb()
        {
            cell.Check();
            Assert.AreEqual(cell.Status, StatusEnum.Revealed);
        }

        [TestMethod]
        [ExpectedException(typeof(GameOverException))]
        public void CheckCellWithBomb()
        {
            cell.SetBomb();
            cell.Check();
        }
    }
}
