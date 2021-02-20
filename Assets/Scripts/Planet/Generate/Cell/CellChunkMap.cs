using System.Collections.Generic;
using UnityEngine;

namespace Planet.Generate.Cell
{
    public class CellChunkMap
    {
        public readonly Dictionary<Vector2Int, CellChunk> cellChunks;

        public CellChunkMap()
        {
            cellChunks = new Dictionary<Vector2Int, CellChunk>();
        }

        public void AddChunk(CellChunk cellChunk)
        {
            cellChunks.Add(cellChunk.chunkPosition, cellChunk);
        }

        public void DeleteChunk(Vector2Int chunkPosition)
        {
            if (!ChunkExist(chunkPosition)) return;

            var parent = cellChunks[chunkPosition].parent;
            foreach (Transform n in parent.transform) Object.Destroy(n.gameObject);

            Object.Destroy(parent.gameObject);

            cellChunks.Remove(chunkPosition);
        }

        public bool ChunkExist(Vector2Int chunkPosition)
        {
            return cellChunks.ContainsKey(chunkPosition);
        }
    }
}
