using FluentAssertions;
using Minesweeper.Domain.Core.FieldBuilder;
using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Model;
using Minesweeper.Test.Helper;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace Minesweeper.Test.Domain.Core.FieldBuilder.Unit
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

            sourceCells = FieldHelper.InstanciateField3x3();
            expectedCells = FieldHelper.InstanciateField3x3();

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
