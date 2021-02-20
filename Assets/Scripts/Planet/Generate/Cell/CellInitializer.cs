using UnityEngine;
using VContainer;

namespace Planet.Generate.Cell
{
    public class CellInitializer
    {
        private readonly GenerateSettings _generateSettings;

        [Inject]
        public CellInitializer(GenerateSettings generateSettings)
        {
            _generateSettings = generateSettings;
        }

        public CellChunk Initialize(Vector2Int chunkPosition)
        {
            var cells = new Cell[_generateSettings.chunkCellRowCount, _generateSettings.chunkCellColumnCount];

            var cellBasePosition =
                new Vector2(_generateSettings.cellSize * _generateSettings.chunkCellRowCount * chunkPosition.x, _generateSettings.cellSize * _generateSettings.chunkCellColumnCount * chunkPosition.y);

            for (var x = 0; x < _generateSettings.chunkCellRowCount; x++)
            for (var y = 0; y < _generateSettings.chunkCellColumnCount; y++)
            {
                var xMin = x * _generateSettings.cellSize -
                           _generateSettings.cellSize * _generateSettings.chunkCellRowCount / 2;
                var xMax = (x + 1) * _generateSettings.cellSize -
                           _generateSettings.cellSize * _generateSettings.chunkCellRowCount / 2;

                var yMin = y * _generateSettings.cellSize;
                var yMax = (y + 1) * _generateSettings.cellSize;

                cells[x, y] = new Cell(cellBasePosition + new Vector2(xMin, yMin),
                    cellBasePosition + new Vector2(xMax, yMax));
            }

            var cellChunk = new CellChunk(cells, chunkPosition);

            return cellChunk;
        }
    }
}
