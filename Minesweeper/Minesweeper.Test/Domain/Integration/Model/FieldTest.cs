using FluentAssertions;
using Minesweeper.Domain.Enumerator;
using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Level;
using Minesweeper.Domain.Model;
using Minesweeper.Library.Extension;
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

        [Test]
        public void CheckCellInTheField()
        {
            field = new Field(fieldLevel);
            var position = GetPositionWitoutBombs(field.Cells);
            field.Check(position[0], position[1]);
            field.Cells[position[0], position[1]].Status.Should().Be(StatusEnum.Revealed);
        }

        [Test]
        public void FlagCellInTheField()
        {
            field = new Field(fieldLevel);
            field.Flag(0, 0);
            field.Cells[0,0].Status.Should().Be(StatusEnum.Flagged);
        }

        private int[] GetPositionWitoutBombs(Cell[,] cells)
        {
            var position = new int[2];
            var dimensions = cells.GetDimensionsLength();
            for (var row = 0; row< dimensions[0]; row++)
            {
                for(var collumn = 0; collumn < dimensions[1]; collumn++)
                {
                    if(!cells[row, collumn].HasBomb)
                    {
                        position[0] = row;
                        position[1] = collumn;
                        return position;
                    }
                }
            }
            return null;
        }
    }
}
