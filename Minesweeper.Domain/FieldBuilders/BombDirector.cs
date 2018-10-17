using System.Collections.Generic;
using System.Linq;
using Minesweeper.Domain.Extensions;
using Minesweeper.Domain.Interfaces;
using Minesweeper.Domain.Models;

namespace Minesweeper.Domain.FieldBuilders
{
    public class BombDirector : IBombDirector
    {
        private IBombGenerator _bombGenerator;
        private Cell[,] _cells;

        public BombDirector(IBombGenerator bombGenerator)
        {
            _bombGenerator = bombGenerator;
        }

        public Cell[,] GenerateBombs(Cell[,] cells, int quantityBombs)
        {
            _cells = cells;
            var bombsPosition = GenerateBombsPosition(quantityBombs);
            return PlaceBombsInField(bombsPosition);
        }

        private List<Position> GenerateBombsPosition(int quantityBombs)
        {
            var dimensionsLength = _cells.GetDimensionsLength();
            var quantityCollumns = dimensionsLength.LastOrDefault();

            return _bombGenerator.GenerateBombsPosition(quantityBombs, GetFieldSize(), quantityCollumns);
        }

        private Cell[,] PlaceBombsInField(List<Position> bombsPosition)
        {
            foreach (var position in bombsPosition)
                _cells.GetCell(position).SetBomb();

            return _cells;
        }

        private int GetFieldSize()
        {
            var dimensionsLength = _cells.GetDimensionsLength();
            return dimensionsLength.FirstOrDefault() * dimensionsLength.LastOrDefault();
        }
    }
}