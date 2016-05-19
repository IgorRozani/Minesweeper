using FluentAssertions;
using Minesweeper.Domain.Core.GameMechanic;
using Minesweeper.Domain.Core.Helper;
using Minesweeper.Domain.Model;
using Minesweeper.Test.Helper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Test.Domain.Helper.Unit
{
    [TestFixture]
    public class IdentifyCellsAroundTest
    {
        private IdentifyCellsAround identifiedCellsAround;
        private Cell[,] field;
        private Position position;

        [SetUp]
        public void Initialize()
        {
            identifiedCellsAround = new IdentifyCellsAround();

            field = FieldHelper.InstanciateField3x3();

            position = null;
        }
        [Test]
        public void IdentifyCellArroundInAFieldInTheMiddle()
        {
            position = new Position(1, 1);
            var result = identifiedCellsAround.Identify(field, position);
            result.Should().HaveCount(8);
        }
    }
}
