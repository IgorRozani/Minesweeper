using FluentAssertions;
using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Level;
using Minesweeper.Domain.Model;
using NUnit.Framework;

namespace Minesweeper.Test.Domain.Integration.Model
{
    [TestFixture]
    public class FieldTest
    {
        private const int QUANTITY_COLUMNS = 10;
        private const int QUANTITY_ROWS = 10;

        private IFieldLevel fieldLevel;
        private Field field;

        [OneTimeSetUp]
        public void Initialize()
        {
            fieldLevel = new EasyLevel();
        }

        [Test]
        public void FieldHasCellsNotNull()
        {
            field = new Field(fieldLevel);
            field.Cells.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void FieldHasValueInFieldLevel()
        {
            field = new Field(fieldLevel);
            field.FieldLevel.Should().NotBeNull();
        }
    }
}
