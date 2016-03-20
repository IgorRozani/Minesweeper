using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Core.Builder;
using NSubstitute;

namespace Minesweeper.Test.BuilderTests
{
    [TestClass]
    public class FieldDirectorTest
    {
        private const int QUANTITY_COLUMNS = 10;
        private const int QUANTITY_ROWS = 10;

        private FieldDirector mockFieldDirector;
        private LevelBuilder mockLevelBuilder;

        [TestInitialize]
        public void InitializeTests()
        {
            mockLevelBuilder = Substitute.For<LevelBuilder>();
            mockLevelBuilder.QuantityCollumns().Returns(QUANTITY_COLUMNS);
            mockLevelBuilder.QuantityRows().Returns(QUANTITY_ROWS);

            mockFieldDirector = new FieldDirector(mockLevelBuilder);
        }

        [TestMethod]
        public void FieldDirectorGenerateCellsNotNull()
        {
            var field = mockFieldDirector.CreateField();
            CollectionAssert.AllItemsAreNotNull(field);
        }
    }
}
