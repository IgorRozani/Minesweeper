using Minesweeper.Domain.Interface;
using Minesweeper.Domain.Model;
using Minesweeper.Library.Extension;
using System.Collections.Generic;
using System.Linq;

namespace Minesweeper.Domain.Builder
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

        private List<int> GenerateBombsPosition(int quantityBombs)
        {
            return _bombGenerator.GenerateBombsPosition(quantityBombs, GetFieldSize());
        }

        private Cell[,] PlaceBombsInField(List<int> bombsPosition)
        {
            var dimensionsLength = _cells.GetDimensionsLength();
            var quantityCollumns = dimensionsLength.LastOrDefault();

            foreach (var bombPosition in bombsPosition)
            {
                if (bombPosition == 0)
                    _cells[0, 0].SetBomb();
                else
                {
                    var row = bombPosition / quantityCollumns;
                    var collumn = bombPosition % quantityCollumns;
                    _cells[row, collumn].SetBomb();
                }
            }
            return _cells;
        }

        private int GetFieldSize()
        {
            var dimensionsLength = _cells.GetDimensionsLength();
            return dimensionsLength.FirstOrDefault() * dimensionsLength.LastOrDefault();
        }
    }
}
