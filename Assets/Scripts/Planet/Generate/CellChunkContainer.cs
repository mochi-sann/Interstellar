using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellChunkContainer
{
    public readonly List<CellChunk> cellGroup = new List<CellChunk>();

    public int CellGroupCount => cellGroup.Count;

    public void AddCellGroup(CellChunk cellChunk)
    {
        cellGroup.Add(cellChunk);
    }

    public void DeleteCellGroup(Vector2Int chunkPosition)
    {
        var objectToDelete = cellGroup.Single(chunk => chunk.position == chunkPosition);
        objectToDelete.DestroyChunk();
        cellGroup.Remove(objectToDelete);
    }

    public bool CellChunkExist(Vector2Int chunkPosition)
    {
        return cellGroup.Any(cellChunk => cellChunk.position == chunkPosition);
    }
}