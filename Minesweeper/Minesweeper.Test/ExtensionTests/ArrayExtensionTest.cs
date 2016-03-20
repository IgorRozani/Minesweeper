using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Library.Extension;
using System.Collections.Generic;

namespace Minesweeper.Test.ExtensionTests
{
    [TestClass]
    public class ArrayExtensionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetDimensionsLengthOfNullArray()
        {
            int[] array = null;
            array.GetDimensionsLength();
        }

        [TestMethod]
        public void GetDimensionsLengthOfOneDimensionArray()
        {
            var array = new int[12];
            var lengths = array.GetDimensionsLength();
            CollectionAssert.AreEqual(new List<int> { 12 }, lengths);
        }

        [TestMethod]
        public void GetDimensionsLengthOfTwoDimensionsArray()
        {
            var array = new int[12, 15];
            var lengths = array.GetDimensionsLength();
            CollectionAssert.AreEqual(new List<int> { 12, 15 }, lengths);
        }

        [TestMethod]
        public void GetDimensionsLengthOfThreeDimensionsArray()
        {
            var array = new int[12, 15, 5];
            var lengths = array.GetDimensionsLength();
            CollectionAssert.AreEqual(new List<int> { 12, 15, 5 }, lengths);
        }

        [TestMethod]
        public void GetDimensionsLengthOfFourDimensionsArray()
        {
            var array = new int[12, 15, 5, 30];
            var lengths = array.GetDimensionsLength();
            CollectionAssert.AreEqual(new List<int> { 12, 15, 5, 30 }, lengths);
        }

        [TestMethod]
        public void GetDimensionsLengthOfArrayOfArray()
        {
            var array = new int[2][];
            array[0] = new int[3];
            array[1] = new int[5];
            var lengths = array.GetDimensionsLength();
            CollectionAssert.AreEqual(new List<int> { 2 }, lengths);
        }
    }
}
