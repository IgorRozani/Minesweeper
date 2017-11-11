using System.Collections.Generic;
using FluentAssertions;
using Minesweeper.Domain.Core.Helper;
using Minesweeper.Domain.Model;
using Minesweeper.Test.Helper;
using NUnit.Framework;

namespace Minesweeper.Test.Domain.Core.Helper.Unit
{
    [TestFixture]
    public class IdentifyCellsAroundTest
    {
        private IdentifyCellsAround _identifiedCellsAround;
        private Cell[,] _field;
        private Position _position;
        private List<Position> _expectedPositions;

        [SetUp]
        public void Initialize()
        {
            _identifiedCellsAround = new IdentifyCellsAround();

            _field = FieldHelper.InstanciateField3X3();

            _position = null;

            _expectedPositions = new List<Position>();
        }

        [Test]
        public void IdentifyCellArroundFirstCellInFirstRow()
        {
            _position = new Position(0, 0);
            _expectedPositions.Add(new Position(0, 1));
            _expectedPositions.Add(new Position(1, 0));
            _expectedPositions.Add(new Position(1, 1));

            var result = _identifiedCellsAround.Identify(_field, _position);
            result.ShouldAllBeEquivalentTo(_expectedPositions);
        }

        [Test]
        public void IdentifyCellArroundMiddleCellInFirstRow()
        {
            _position = new Position(0, 1);
            _expectedPositions.Add(new Position(0, 0));
            _expectedPositions.Add(new Position(0, 2));
            _expectedPositions.Add(new Position(1, 0));
            _expectedPositions.Add(new Position(1, 1));
            _expectedPositions.Add(new Position(1, 2));

            var result = _identifiedCellsAround.Identify(_field, _position);
            result.ShouldAllBeEquivalentTo(_expectedPositions);
        }

        [Test]
        public void IdentifyCellArroundLastCellInFirstRow()
        {
            _position = new Position(0, 2);
            _expectedPositions.Add(new Position(0, 1));
            _expectedPositions.Add(new Position(1, 1));
            _expectedPositions.Add(new Position(1, 2));

            var result = _identifiedCellsAround.Identify(_field, _position);
            result.ShouldAllBeEquivalentTo(_expectedPositions);
        }

        [Test]
        public void IdentifyCellArroundFirstCellInMiddleRow()
        {
            _position = new Position(1, 0);
            _expectedPositions.Add(new Position(0, 0));
            _expectedPositions.Add(new Position(0, 1));
            _expectedPositions.Add(new Position(1, 1));
            _expectedPositions.Add(new Position(2, 0));
            _expectedPositions.Add(new Position(2, 1));

            var result = _identifiedCellsAround.Identify(_field, _position);
            result.ShouldAllBeEquivalentTo(_expectedPositions);
        }

        [Test]
        public void IdentifyCellArroundMiddleField()
        {
            _position = new Position(1, 1);
            _expectedPositions.Add(new Position(0, 0));
            _expectedPositions.Add(new Position(0, 1));
            _expectedPositions.Add(new Position(0, 2));
            _expectedPositions.Add(new Position(1, 0));
            _expectedPositions.Add(new Position(1, 2));
            _expectedPositions.Add(new Position(2, 0));
            _expectedPositions.Add(new Position(2, 1));
            _expectedPositions.Add(new Position(2, 2));

            var result = _identifiedCellsAround.Identify(_field, _position);
            result.ShouldAllBeEquivalentTo(_expectedPositions);
        }

        [Test]
        public void IdentifyCellArroundLastCellInMiddleRow()
        {
            _position = new Position(1, 2);
            _expectedPositions.Add(new Position(0, 1));
            _expectedPositions.Add(new Position(0, 2));
            _expectedPositions.Add(new Position(1, 1));
            _expectedPositions.Add(new Position(2, 1));
            _expectedPositions.Add(new Position(2, 2));

            var result = _identifiedCellsAround.Identify(_field, _position);
            result.ShouldAllBeEquivalentTo(_expectedPositions);
        }

        [Test]
        public void IdentifyCellArroundFirstCellInLastRow()
        {
            _position = new Position(2, 0);
            _expectedPositions.Add(new Position(1, 0));
            _expectedPositions.Add(new Position(1, 1));
            _expectedPositions.Add(new Position(2, 1));

            var result = _identifiedCellsAround.Identify(_field, _position);
            result.ShouldAllBeEquivalentTo(_expectedPositions);
        }

        [Test]
        public void IdentifyCellArroundMiddleCellInLastRow()
        {
            _position = new Position(2, 1);
            _expectedPositions.Add(new Position(1, 0));
            _expectedPositions.Add(new Position(1, 1));
            _expectedPositions.Add(new Position(1, 2));
            _expectedPositions.Add(new Position(2, 0));
            _expectedPositions.Add(new Position(2, 2));

            var result = _identifiedCellsAround.Identify(_field, _position);
            result.ShouldAllBeEquivalentTo(_expectedPositions);
        }

        [Test]
        public void IdentifyCellArroundLastCellInLastRow()
        {
            _position = new Position(2, 2);
            _expectedPositions.Add(new Position(1, 1));
            _expectedPositions.Add(new Position(1, 2));
            _expectedPositions.Add(new Position(2, 1));

            var result = _identifiedCellsAround.Identify(_field, _position);
            result.ShouldAllBeEquivalentTo(_expectedPositions);
        }
    }
}
