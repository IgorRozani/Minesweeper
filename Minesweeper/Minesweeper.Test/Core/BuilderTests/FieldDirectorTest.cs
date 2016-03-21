﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Core;
using Minesweeper.Core.Builder;
using Minesweeper.Core.Interface;
using NSubstitute;

namespace Minesweeper.Test.Core.BuilderTests
{
    [TestClass]
    public class FieldDirectorTest
    {
        private const int QUANTITY_COLUMNS = 10;
        private const int QUANTITY_ROWS = 10;

        private Field field;
        private FieldDirector mockFieldDirector;
        private IFieldLevel mockFieldLevel;
        private INearBombCalculator mockNearBombCalculator;
        private IBombDirector mockBombDirector;

        [TestInitialize]
        public void InitializeTests()
        {
            mockFieldLevel = Substitute.For<IFieldLevel>();
            mockFieldLevel.QuantityCollumns().Returns(QUANTITY_COLUMNS);
            mockFieldLevel.QuantityRows().Returns(QUANTITY_ROWS);

            field = new Field(mockFieldLevel);

            mockNearBombCalculator = Substitute.For<INearBombCalculator>();

            mockBombDirector = Substitute.For<IBombDirector>();
            mockBombDirector.GenerateBombs(field.Cells, field.FieldLevel.QuantiyBombs()).Returns(field.Cells);

            mockFieldDirector = new FieldDirector(mockBombDirector, mockNearBombCalculator);

        }

        [TestMethod]
        public void FieldDirectorGenerateCellsNotNull()
        {
            var generateField = mockFieldDirector.CreateField(field);
            CollectionAssert.AllItemsAreNotNull(generateField.Cells);
        }
    }
}