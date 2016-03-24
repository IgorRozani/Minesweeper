using FluentAssertions;
using Minesweeper.Core;
using Minesweeper.Core.Builder;
using Minesweeper.Core.Interface;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace Minesweeper.Test.Core.BuilderTest
{
    [TestFixture]
    public class BombGeneratorTest
    {
        private const int QUANTITY_BOMBS = 1;
        private const int FIELD_SIZE = 9;

        private List<int> bombsPosition;
        private BombDirector bombDirector;
        private Cell[,] sourceCells;
        private Cell[,] expectedCells;

        private IBombGenerator mockBombGenerator;

        [SetUp]
        public void InitializeTests()
        {
            bombsPosition = new List<int>();

            sourceCells = new Cell[3, 3];
            sourceCells[0, 0] = new Cell();
            sourceCells[0, 1] = new Cell();
            sourceCells[0, 2] = new Cell();
            sourceCells[1, 0] = new Cell();
            sourceCells[1, 1] = new Cell();
            sourceCells[1, 2] = new Cell();
            sourceCells[2, 0] = new Cell();
            sourceCells[2, 1] = new Cell();
            sourceCells[2, 2] = new Cell();

            expectedCells = new Cell[3, 3];
            expectedCells[0, 0] = new Cell();
            expectedCells[0, 1] = new Cell();
            expectedCells[0, 2] = new Cell();
            expectedCells[1, 0] = new Cell();
            expectedCells[1, 1] = new Cell();
            expectedCells[1, 2] = new Cell();
            expectedCells[2, 0] = new Cell();
            expectedCells[2, 1] = new Cell();
            expectedCells[2, 2] = new Cell();

            mockBombGenerator = Substitute.For<IBombGenerator>();
        }

        private void ConfigureMocks(List<int> bombsPosition)
        {
            mockBombGenerator.GenerateBombsPosition(QUANTITY_BOMBS, FIELD_SIZE).ReturnsForAnyArgs(bombsPosition);
            bombDirector = new BombDirector(mockBombGenerator);
        }

        [Test]
        public void BombDirectorPlaceBombAtFirstCell()
        {
            bombsPosition.Add(0);
            ConfigureMocks(bombsPosition);

            expectedCells[0, 0].SetBomb();

            var generateCells = bombDirector.GenerateBombs(sourceCells, QUANTITY_BOMBS);

            generateCells.ShouldBeEquivalentTo(expectedCells);
        }

        [Test]
        public void BombDirectorPlaceBombAtRow2Collumn2()
        {
            bombsPosition.Add(4);
            ConfigureMocks(bombsPosition);

            expectedCells[1, 1].SetBomb();

            var generateCells = bombDirector.GenerateBombs(sourceCells, QUANTITY_BOMBS);
            generateCells.ShouldBeEquivalentTo(expectedCells);
        }

        [Test]
        public void BombDirectorPlaceBombAtRow3Collumn1()
        {
            bombsPosition.Add(6);
            ConfigureMocks(bombsPosition);

            expectedCells[2, 0].SetBomb();

            var generateCell = bombDirector.GenerateBombs(sourceCells, QUANTITY_BOMBS);
            generateCell.ShouldBeEquivalentTo(expectedCells);
        }

        [Test]
        public void BombDirectorPlaceBombAtFirstRowCollumn3()
        {
            bombsPosition.Add(2);
            ConfigureMocks(bombsPosition);

            expectedCells[0, 2].SetBomb();

            var generateCell = bombDirector.GenerateBombs(sourceCells, QUANTITY_BOMBS);
            generateCell.ShouldBeEquivalentTo(expectedCells);
        }

        [Test]
        public void BombDirectorPlaceBombAtLastCell()
        {
            bombsPosition.Add(8);
            ConfigureMocks(bombsPosition);

            expectedCells[2, 2].SetBomb();

            var generateCell = bombDirector.GenerateBombs(sourceCells, QUANTITY_BOMBS);
            generateCell.ShouldBeEquivalentTo(expectedCells);
        }

        [Test]
        public void BombDirectorPlaceTwoBombs()
        {
            bombsPosition.AddRange(new List<int> { 7, 8 });
            ConfigureMocks(bombsPosition);

            expectedCells[2, 1].SetBomb();
            expectedCells[2, 2].SetBomb();

            var generateCell = bombDirector.GenerateBombs(sourceCells, QUANTITY_BOMBS);
            generateCell.ShouldBeEquivalentTo(expectedCells);
        }

        [Test]
        public void BombDirectorPlaceBombsInAllCells()
        {
            bombsPosition.AddRange(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 });
            ConfigureMocks(bombsPosition);

            expectedCells[0, 0].SetBomb();
            expectedCells[0, 1].SetBomb();
            expectedCells[0, 2].SetBomb();
            expectedCells[1, 0].SetBomb();
            expectedCells[1, 1].SetBomb();
            expectedCells[1, 2].SetBomb();
            expectedCells[2, 0].SetBomb();
            expectedCells[2, 1].SetBomb();
            expectedCells[2, 2].SetBomb();

            var generateCell = bombDirector.GenerateBombs(sourceCells, QUANTITY_BOMBS);
            generateCell.ShouldBeEquivalentTo(expectedCells);
        }
    }
}
