using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Library.Exceptions;
using Minesweeper.Model;

namespace Minesweeper.Test
{
    [TestClass]
    public class CellTest
    {
        [TestMethod]
        public void CreateCellWithBomb()
        {
            var cell = new Cell(true);
            Assert.IsTrue(cell.HasBomb && cell.Status == StatusEnum.Untouched);
        }

        [TestMethod]
        public void CreateCellWithoutBomb()
        {
            var cell = new Cell(false);
            Assert.IsTrue(!cell.HasBomb && cell.Status == StatusEnum.Untouched);
        }

        [TestMethod]
        public void FlagCell()
        {
            var cell = new Cell(false);
            cell.Flagged();
            Assert.AreEqual(cell.Status, StatusEnum.Flagged);
        }

        [TestMethod]
        public void CheckCellWithoutBomb()
        {
            var cell = new Cell(false);
            cell.Check();
            Assert.AreEqual(cell.Status, StatusEnum.Revealed);
        }

        [TestMethod]
        [ExpectedException(typeof(GameOverException))]
        public void CheckCellWithBomb()
        {
            var cell = new Cell(true);
            cell.Check();
        }
    }
}
