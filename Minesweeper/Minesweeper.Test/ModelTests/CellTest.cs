using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Library.Exceptions;
using Minesweeper.Model;
using Minesweeper.Model.Enumerators;

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
            cell.Configure(true, 0);
            Assert.IsTrue(cell.HasBomb);
        }

        public void ConfigureCellWithoutBomb()
        {
            cell.Configure(false, 0);
            Assert.IsFalse(cell.HasBomb);
        }

        [TestMethod]
        public void ConfigureCellWith5BombsNear()
        {
            cell.Configure(false, 5);
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
            cell.Configure(true, 0);
            cell.Check();
        }
    }
}
