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
        private Cell[,] array;
        private Position position;

        [SetUp]
        public void Initialize()
        {
            array = null;
            position = new Position(0, 0);
        }

        [Test]
        public void GetDimensionsLengthFromNullArray()
        {
            Action action = () => array.GetDimensionsLength();
            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Test]
        public void GetDimensionsLengthFrom12x15Array()
        {
            array = new Cell[12, 15];
            var lengths = array.GetDimensionsLength();
            lengths.Should().NotBeEmpty().And.HaveSameCount(new List<int> { 12, 15 });
        }

        [Test]
        public void GetCellFromNullArray()
        {
            Action action = () => array.GetCell(position);
            action.ShouldThrow<NullReferenceException>();
        }

        [Test]
        public void GetCellFrom12x15Array()
        {
            array = new Cell[12, 15];
            array[0, 0] = new Cell();
            var cell = array.GetCell(position);
            cell.Should().NotBeNull();
        }
    }
}
