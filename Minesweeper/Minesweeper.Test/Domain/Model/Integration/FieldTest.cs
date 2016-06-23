using FluentAssertions;
using Minesweeper.Domain.Enumerator;
using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Level;
using Minesweeper.Domain.Model;
using Minesweeper.Domain.Extension;
using NUnit.Framework;

namespace Minesweeper.Test.Domain.Model.Integration
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
        public void FieldHasNotCellsNull()
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

        [Test]
        public void CheckCellInTheFieldWithoutBombAndWithNearBomb()
        {
            field = new Field(fieldLevel);
            var position = GetPositionWitoutBombs(field.Cells);
            field.Check(position);
            field.Cells[position.Row, position.Collumn].Status.Should().Be(StatusEnum.Revealed);
        }

        [Test]
        public void FlagCellInTheField()
        {
            var position = new Position(0, 0);
            field = new Field(fieldLevel);
            field.Flag(position);
            field.Cells[position.Row, position.Collumn].Status.Should().Be(StatusEnum.Flagged);
        }

        [Test]
        public void UnflagCellInTheField()
        {
            var position = new Position(0, 0);
            field = new Field(fieldLevel);
            field.Flag(position);
            field.Unflag(position);
            field.Cells[position.Row, position.Collumn].Status.Should().Be(StatusEnum.Untouched);
        }

        private Position GetPositionWitoutBombs(Cell[,] cells)
        {
            var position = new int[2];
            var dimensions = cells.GetDimensionsLength();
            for (var row = 0; row < dimensions[0]; row++)
            {
                for (var collumn = 0; collumn < dimensions[1]; collumn++)
                {
                    if (!cells[row, collumn].HasBomb)
                        return new Position(row, collumn);
                }
            }
            return null;
        }
    }
}
