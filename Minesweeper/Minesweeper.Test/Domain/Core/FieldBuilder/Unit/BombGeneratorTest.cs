using FluentAssertions;
using Minesweeper.Domain.Core.FieldBuilder;
using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Model;
using Minesweeper.Test.Helper;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Minesweeper.Test.Domain.Core.FieldBuilder.Unit
{
    [TestFixture]
    public class BombGeneratorTest
    {
        private const int QUANTITY_BOMBS = 1;
        private const int FIELD_SIZE = 9;
        private const int QUANTITY_COLUMNS = 3;

        private List<Position> bombsPosition;
        private BombDirector bombDirector;
        private Cell[,] sourceCells;
        private Cell[,] expectedCells;

        private IBombGenerator mockBombGenerator;

        [SetUp]
        public void InitializeTests()
        {
            bombsPosition = new List<Position>();

            sourceCells = FieldHelper.InstanciateField3x3();
            expectedCells = FieldHelper.InstanciateField3x3();

            mockBombGenerator = Substitute.For<IBombGenerator>();
        }

        private void ConfigureMocks(List<Position> bombsPosition)
        {
            mockBombGenerator.GenerateBombsPosition(QUANTITY_BOMBS, FIELD_SIZE, QUANTITY_COLUMNS).ReturnsForAnyArgs(bombsPosition);
            bombDirector = new BombDirector(mockBombGenerator);
        }

        [Test]
        public void BombDirectorPlaceBombAtFirstCell()
        {
            bombsPosition.Add(new Position(0, 0));
            ConfigureMocks(bombsPosition);

            expectedCells[0, 0].SetBomb();

            var generateCells = bombDirector.GenerateBombs(sourceCells, QUANTITY_BOMBS);

            generateCells.ShouldBeEquivalentTo(expectedCells);
        }

        [Test]
        public void BombDirectorPlaceBombAtRow2Collumn2()
        {
            bombsPosition.Add(new Position(1, 1));
            ConfigureMocks(bombsPosition);

            expectedCells[1, 1].SetBomb();

            var generateCells = bombDirector.GenerateBombs(sourceCells, QUANTITY_BOMBS);
            generateCells.ShouldBeEquivalentTo(expectedCells);
        }

        [Test]
        public void BombDirectorPlaceBombAtRow3Collumn1()
        {
            bombsPosition.Add(new Position(2, 0));
            ConfigureMocks(bombsPosition);

            expectedCells[2, 0].SetBomb();

            var generateCell = bombDirector.GenerateBombs(sourceCells, QUANTITY_BOMBS);
            generateCell.ShouldBeEquivalentTo(expectedCells);
        }

        [Test]
        public void BombDirectorPlaceBombAtFirstRowCollumn3()
        {
            throw new Exception();
            bombsPosition.Add(new Position(0, 2));
            ConfigureMocks(bombsPosition);

            expectedCells[0, 2].SetBomb();

            var generateCell = bombDirector.GenerateBombs(sourceCells, QUANTITY_BOMBS);
            generateCell.ShouldBeEquivalentTo(expectedCells);
        }

        [Test]
        public void BombDirectorPlaceBombAtLastCell()
        {
            bombsPosition.Add(new Position(2, 2));
            ConfigureMocks(bombsPosition);

            expectedCells[2, 2].SetBomb();

            var generateCell = bombDirector.GenerateBombs(sourceCells, QUANTITY_BOMBS);
            generateCell.ShouldBeEquivalentTo(expectedCells);
        }

        [Test]
        public void BombDirectorPlaceTwoBombs()
        {
            bombsPosition.AddRange(new List<Position> { new Position(2, 1), new Position(2, 2) });
            ConfigureMocks(bombsPosition);

            expectedCells[2, 1].SetBomb();
            expectedCells[2, 2].SetBomb();

            var generateCell = bombDirector.GenerateBombs(sourceCells, QUANTITY_BOMBS);
            generateCell.ShouldBeEquivalentTo(expectedCells);
        }

        [Test]
        public void BombDirectorPlaceBombsInAllCells()
        {
            bombsPosition.AddRange(new List<Position> {
                new Position(0, 0),
                             new Position(0, 1),
                             new Position(0, 2),
                             new Position(1, 0),
                             new Position(1, 1),
                             new Position(1, 2),
                             new Position(2, 0),
                             new Position(2, 1),
                             new Position(2, 2)
});
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
