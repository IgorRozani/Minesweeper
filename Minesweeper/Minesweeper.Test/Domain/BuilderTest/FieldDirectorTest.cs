using Minesweeper.Domain.Builder;
using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Model;
using NSubstitute;
using NUnit.Framework;

namespace Minesweeper.Test.Domain.BuilderTest
{
    [TestFixture]
    public class FieldDirectorTest
    {
        private const int QUANTITY_COLUMNS = 10;
        private const int QUANTITY_ROWS = 10;

        private Field field;
        private FieldDirector mockFieldDirector;
        private IFieldLevel mockFieldLevel;
        private INearBombCalculator mockNearBombCalculator;
        private IBombDirector mockBombDirector;

        [SetUp]
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

        [Test]
        public void FieldDirectorGenerateCellsNotNull()
        {
            var generateField = mockFieldDirector.CreateField(field);

            CollectionAssert.AllItemsAreNotNull(generateField.Cells);
        }
    }
}
