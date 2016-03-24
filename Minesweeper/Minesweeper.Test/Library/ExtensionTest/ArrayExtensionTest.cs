using FluentAssertions;
using Minesweeper.Library.Extension;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Minesweeper.Test.Library.ExtensionTest
{
    [TestFixture]
    public class ArrayExtensionTest
    {
        [Test]
        public void GetDimensionsLengthOfNullArray()
        {
            int[] array = null;
            Action act = () => array.GetDimensionsLength();
            act.ShouldThrow<ArgumentNullException>();
            //Assert.Throws<ArgumentNullException>(() => array.GetDimensionsLength());
        }

        [Test]
        public void GetDimensionsLengthOfOneDimensionArray()
        {
            var array = new int[12];
            var lengths = array.GetDimensionsLength();
            lengths.Should().NotBeEmpty().And.HaveSameCount(new List<int> { 12 });
            //CollectionAssert.AreEqual(new List<int> { 12 }, lengths);
        }

        [Test]
        public void GetDimensionsLengthOfTwoDimensionsArray()
        {
            var array = new int[12, 15];
            var lengths = array.GetDimensionsLength();
            lengths.Should().NotBeEmpty().And.HaveSameCount(new List<int> { 12, 15 });
        }

        [Test]
        public void GetDimensionsLengthOfThreeDimensionsArray()
        {
            var array = new int[12, 15, 5];
            var lengths = array.GetDimensionsLength();
            lengths.Should().NotBeEmpty().And.HaveSameCount(new List<int> { 12, 15, 5 });
        }

        [Test]
        public void GetDimensionsLengthOfFourDimensionsArray()
        {
            var array = new int[12, 15, 5, 30];
            var lengths = array.GetDimensionsLength();
            lengths.Should().NotBeEmpty().And.HaveSameCount(new List<int> { 12, 15, 5, 30 });
        }

        [Test]
        public void GetDimensionsLengthOfArrayOfArray()
        {
            var array = new int[2][];
            array[0] = new int[3];
            array[1] = new int[5];
            var lengths = array.GetDimensionsLength();
            lengths.Should().NotBeEmpty().And.HaveSameCount(new List<int> { 2 });
        }
    }
}
