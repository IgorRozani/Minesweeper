using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Core;
using Minesweeper.Core.Builder;
using Minesweeper.Core.Interface;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper.Test.Core.BuilderTests
{
    [TestClass]
    public class BombDirectorTest
    {
        private const int QUANTITY_BOMBS = 1;
        private const int FIELD_SIZE = 9;

        private List<int> bombsPosition;
        private BombDirector bombDirector;
        private Cell[,] instanciateCells;

        private IBombGenerator mockBombGenerator;

        [TestInitialize]
        public void InitializeTests()
        {
            bombsPosition = new List<int>();

            instanciateCells = new Cell[3, 3];
            instanciateCells[0, 0] = new Cell();
            instanciateCells[0, 1] = new Cell();
            instanciateCells[0, 2] = new Cell();
            instanciateCells[1, 0] = new Cell();
            instanciateCells[1, 1] = new Cell();
            instanciateCells[1, 2] = new Cell();
            instanciateCells[2, 0] = new Cell();
            instanciateCells[2, 1] = new Cell();
            instanciateCells[2, 2] = new Cell();

            mockBombGenerator = Substitute.For<IBombGenerator>();
        }

        private void ConfigureMocks(List<int> bombsPosition)
        {
            mockBombGenerator.GenerateBombsPosition(QUANTITY_BOMBS, FIELD_SIZE).ReturnsForAnyArgs(bombsPosition);
            bombDirector = new BombDirector(mockBombGenerator);
        }

        [TestMethod]
        public void BombDirectorPlaceBombAtFirstCell()
        {
            bombsPosition.Add(0);
            ConfigureMocks(bombsPosition);

            var generateCells = bombDirector.GenerateBombs(instanciateCells, QUANTITY_BOMBS);
            Assert.IsTrue(generateCells[0, 0].HasBomb);
        }

        [TestMethod]
        public void BombDirectorPlaceBombAtRow2Collumn2()
        {
            bombsPosition.Add(4);
            ConfigureMocks(bombsPosition);

            var generateCells = bombDirector.GenerateBombs(instanciateCells, QUANTITY_BOMBS);
            Assert.IsTrue(generateCells[1, 1].HasBomb);
        }

        [TestMethod]
        public void BombDirectorPlaceBombAtRow3Collumn1()
        {
            bombsPosition.Add(6);
            ConfigureMocks(bombsPosition);

            var generateCell = bombDirector.GenerateBombs(instanciateCells, QUANTITY_BOMBS);
            Assert.IsTrue(generateCell[2, 0].HasBomb);
        }

        [TestMethod]
        public void BombDirectorPlaceBombAtFirstRowCollumn3()
        {
            bombsPosition.Add(2);
            ConfigureMocks(bombsPosition);

            var generateCell = bombDirector.GenerateBombs(instanciateCells, QUANTITY_BOMBS);
            Assert.IsTrue(generateCell[0,2].HasBomb);
        }

        [TestMethod]
        public void BombDirectorPlaceBombAtLastCell()
        {
            bombsPosition.Add(8);
            ConfigureMocks(bombsPosition);

            var generateCell = bombDirector.GenerateBombs(instanciateCells, QUANTITY_BOMBS);
            Assert.IsTrue(generateCell[2, 2].HasBomb);
        }

        [TestMethod]
        public void BombDirectorPlaceOnlyOneBomb()
        {
            bombsPosition.Add(8);
            ConfigureMocks(bombsPosition);

            var generateCell = bombDirector.GenerateBombs(instanciateCells, QUANTITY_BOMBS);
            var quantityBombsPlaced = generateCell.OfType<Cell>().ToList().Count(c => c.HasBomb);
            Assert.AreEqual(QUANTITY_BOMBS, quantityBombsPlaced);
        }
    }
}
