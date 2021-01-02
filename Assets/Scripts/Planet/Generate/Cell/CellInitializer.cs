using UnityEngine;
using VContainer;

public class CellInitializer
{
    [Inject] private GenerateSetting generateSetting;

    public CellChunk Initialize(Vector2Int chunkPosition)
    {
        var cells = new Cell[generateSetting.chunkCellRowCount, generateSetting.chunkCellHeight];

        var cellBasePosition = new Vector2(generateSetting.cellSize * generateSetting.chunkCellRowCount * chunkPosition.x,
            generateSetting.cellSize * generateSetting.chunkCellRowCount * chunkPosition.y);

        for (var x = 0; x < generateSetting.chunkCellRowCount; x++)
        for (var y = 0; y < generateSetting.chunkCellHeight; y++)
        {
            var xMin = x * generateSetting.cellSize - generateSetting.cellSize * generateSetting.chunkCellRowCount / 2;
            var xMax = (x + 1) * generateSetting.cellSize - generateSetting.cellSize * generateSetting.chunkCellRowCount / 2;

            var yMin = y * generateSetting.cellSize;
            var yMax = (y + 1) * generateSetting.cellSize;

            cells[x, y] = new Cell(cellBasePosition + new Vector2(xMin, yMin),
                cellBasePosition + new Vector2(xMax, yMax));
        }

        return new CellChunk(cells, chunkPosition);
    }
}