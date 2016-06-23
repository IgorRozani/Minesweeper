using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Model;
using Minesweeper.Domain.Extension;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper.Domain.Core.Helper
{
    public class IdentifyCellsAround : IIdentifyCellsAround
    {
        private Cell[,] _field;
        private Position _position;
        private int _quantityFieldRows, _quantityFieldCollumns;
        private List<Position> _positionsAround;

        public List<Position> Identify(Cell[,] field, Position position)
        {
            InstanciateObjects(field, position);

            IdentifyPositions();

            return _positionsAround;
        }

        private void InstanciateObjects(Cell[,] field, Position position)
        {
            _position = position;
            _field = field;

            GetDimesionsFromField();

            _positionsAround = new List<Position>();
        }

        private void GetDimesionsFromField()
        {
            var lenghts = _field.GetDimensionsLength();
            _quantityFieldRows = lenghts.FirstOrDefault();
            _quantityFieldCollumns = lenghts.LastOrDefault();
        }

        private void IdentifyPositions()
        {
            if (_position.Row > 0)
                GetPositionsAroundInRow(_position.Row - 1);

            GetPositionsAroundInRow(_position.Row);

            if (_quantityFieldRows - 1 > _position.Row)
                GetPositionsAroundInRow(_position.Row + 1);
        }

        private void GetPositionsAroundInRow(int row)
        {
            if (_position.Collumn > 0)
                _positionsAround.Add(new Position(row, _position.Collumn - 1));
            if (_position.Row != row)
                _positionsAround.Add(new Position(row, _position.Collumn));
            if (_quantityFieldCollumns - 1 > _position.Collumn)
                _positionsAround.Add(new Position(row, _position.Collumn + 1));
        }
    }
}
