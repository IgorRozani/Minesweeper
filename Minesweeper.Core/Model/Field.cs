using Minesweeper.Domain.Core.FieldBuilder;
using Minesweeper.Domain.Core.GameMechanic;
using Minesweeper.Domain.Core.Helper;
using Minesweeper.Domain.Interface;

namespace Minesweeper.Domain.Model
{
    public class Field
    {
        public Field(IFieldLevel fieldLevel)
        {
            FieldLevel = fieldLevel;
            CreateField();
        }

        public Cell[,] Cells { get; private set; }
        public IFieldLevel FieldLevel { get; }
        private ICellsOpener _cellsOpener;

        private void CreateField()
        {
            IIdentifyCellsAround identifyCellsAround = new IdentifyCellsAround();
            INearBombCalculator nearBombCalculator = new NearBombCalculator(identifyCellsAround);

            IBombGenerator bombGenerator = new BombGenerator();
            IBombDirector bombDirector = new BombDirector(bombGenerator);
            IFieldDirector fieldDirector = new FieldDirector(bombDirector, nearBombCalculator);
            Cells = fieldDirector.CreateField(FieldLevel);

            _cellsOpener = new CellsOpener(identifyCellsAround);
        }

        public void Check(Position position)
        {
            GetCell(position).Check();

            //Cells = _cellsOpener.Check(Cells, position);
        }

        public void Flag(Position position)
        {
            GetCell(position).Flag();
        }

        public void Unflag(Position position)
        {
            GetCell(position).Unflag();
        }

        public Cell GetCell(Position position)
        {
            return Cells[position.Row, position.Collumn];
        }
    }
}
