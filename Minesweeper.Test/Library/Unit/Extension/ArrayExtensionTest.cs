using FluentAssertions;
using Minesweeper.Domain.Extension;
using Minesweeper.Domain.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Minesweeper.Test.Library.Unit.Extension
{
    [TestFixture]
    public class CellArrayExtensionTest
    {
        private Cell[,] _array;
        private Position _position;

        [SetUp]
        public void Initialize()
        {
            _array = null;
            _position = new Position(0, 0);
        }

        [Test]
        public void CellArrayExtension_GetDimensionsLength_FromNullArray()
        {
            Action action = () => _array.GetDimensionsLength();
            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Test]
        public void CellArrayExtension_GetDimensionsLength_From12x15Array()
        {
            _array = new Cell[12, 15];
            var lengths = _array.GetDimensionsLength();
            lengths.Should().NotBeEmpty().And.HaveSameCount(new List<int> { 12, 15 });
        }

        [Test]
        public void CellArrayExtension_GetCell_FromNullArray()
        {
            Action action = () => _array.GetCell(_position);
            action.ShouldThrow<NullReferenceException>();
        }

        [Test]
        public void CellArrayExtension_GetCell_From12x15Array()
        {
            _array = new Cell[12, 15];
            _array[0, 0] = new Cell();
            var cell = _array.GetCell(_position);
            cell.Should().NotBeNull();
        }
    }
}
