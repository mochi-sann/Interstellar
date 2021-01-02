using UnityEngine;

public class CellChunk
{
    public Cell[,] cells;
    public Vector2Int position;

    public CellChunk(Cell[,] cells, Vector2Int position)
    {
        this.cells = cells;
        this.position = position;
    }

    public float cellSize => cells[0, 0].size;

    public void DestroyChunk()
    {
        foreach (var cell in cells) cell.DestroyCell();
        cells = null;
    }
}