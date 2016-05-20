using FluentAssertions;
using Minesweeper.Domain.Core.Helper;
using Minesweeper.Domain.Model;
using Minesweeper.Test.Helper;
using NUnit.Framework;
using System.Collections.Generic;

namespace Minesweeper.Test.Domain.Helper.Unit
{
    [TestFixture]
    public class IdentifyCellsAroundTest
    {
        private IdentifyCellsAround identifiedCellsAround;
        private Cell[,] field;
        private Position position;
        private List<Position> expectedPositions;

        [SetUp]
        public void Initialize()
        {
            identifiedCellsAround = new IdentifyCellsAround();

            field = FieldHelper.InstanciateField3x3();

            position = null;

            expectedPositions = new List<Position>();
        }

        [Test]
        public void IdentifyCellArroundFirstCellInFirstRow()
        {
            position = new Position(0, 0);
            expectedPositions.Add(new Position(0, 1));
            expectedPositions.Add(new Position(1, 0));
            expectedPositions.Add(new Position(1, 1));

            var result = identifiedCellsAround.Identify(field, position);
            result.ShouldAllBeEquivalentTo(expectedPositions);
        }

        [Test]
        public void IdentifyCellArroundMiddleCellInFirstRow()
        {
            position = new Position(0, 1);
            expectedPositions.Add(new Position(0, 0));
            expectedPositions.Add(new Position(0, 2));
            expectedPositions.Add(new Position(1, 0));
            expectedPositions.Add(new Position(1, 1));
            expectedPositions.Add(new Position(1, 2));

            var result = identifiedCellsAround.Identify(field, position);
            result.ShouldAllBeEquivalentTo(expectedPositions);
        }

        [Test]
        public void IdentifyCellArroundLastCellInFirstRow()
        {
            position = new Position(0, 2);
            expectedPositions.Add(new Position(0, 1));
            expectedPositions.Add(new Position(1, 1));
            expectedPositions.Add(new Position(1, 2));

            var result = identifiedCellsAround.Identify(field, position);
            result.ShouldAllBeEquivalentTo(expectedPositions);
        }

        [Test]
        public void IdentifyCellArroundFirstCellInMiddleRow()
        {
            position = new Position(1, 0);
            expectedPositions.Add(new Position(0, 0));
            expectedPositions.Add(new Position(0, 1));
            expectedPositions.Add(new Position(1, 1));
            expectedPositions.Add(new Position(2, 0));
            expectedPositions.Add(new Position(2, 1));

            var result = identifiedCellsAround.Identify(field, position);
            result.ShouldAllBeEquivalentTo(expectedPositions);
        }

        [Test]
        public void IdentifyCellArroundMiddleField()
        {
            position = new Position(1, 1);
            expectedPositions.Add(new Position(0, 0));
            expectedPositions.Add(new Position(0, 1));
            expectedPositions.Add(new Position(0, 2));
            expectedPositions.Add(new Position(1, 0));
            expectedPositions.Add(new Position(1, 2));
            expectedPositions.Add(new Position(2, 0));
            expectedPositions.Add(new Position(2, 1));
            expectedPositions.Add(new Position(2, 2));

            var result = identifiedCellsAround.Identify(field, position);
            result.ShouldAllBeEquivalentTo(expectedPositions);
        }

        [Test]
        public void IdentifyCellArroundLastCellInMiddleRow()
        {
            position = new Position(1, 2);
            expectedPositions.Add(new Position(0, 1));
            expectedPositions.Add(new Position(0, 2));
            expectedPositions.Add(new Position(1, 1));
            expectedPositions.Add(new Position(2, 1));
            expectedPositions.Add(new Position(2, 2));

            var result = identifiedCellsAround.Identify(field, position);
            result.ShouldAllBeEquivalentTo(expectedPositions);
        }

        [Test]
        public void IdentifyCellArroundFirstCellInLastRow()
        {
            position = new Position(2, 0);
            expectedPositions.Add(new Position(1, 0));
            expectedPositions.Add(new Position(1, 1));
            expectedPositions.Add(new Position(2, 1));

            var result = identifiedCellsAround.Identify(field, position);
            result.ShouldAllBeEquivalentTo(expectedPositions);
        }

        [Test]
        public void IdentifyCellArroundMiddleCellInLastRow()
        {
            position = new Position(2, 1);
            expectedPositions.Add(new Position(1, 0));
            expectedPositions.Add(new Position(1, 1));
            expectedPositions.Add(new Position(1, 2));
            expectedPositions.Add(new Position(2, 0));
            expectedPositions.Add(new Position(2, 2));

            var result = identifiedCellsAround.Identify(field, position);
            result.ShouldAllBeEquivalentTo(expectedPositions);
        }

        [Test]
        public void IdentifyCellArroundLastCellInLastRow()
        {
            position = new Position(2, 2);
            expectedPositions.Add(new Position(1, 1));
            expectedPositions.Add(new Position(1, 2));
            expectedPositions.Add(new Position(2, 1));

            var result = identifiedCellsAround.Identify(field, position);
            result.ShouldAllBeEquivalentTo(expectedPositions);
        }
    }
}
