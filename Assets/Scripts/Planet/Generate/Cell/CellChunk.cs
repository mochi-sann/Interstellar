using UnityEngine;

namespace Planet.Generate.Cell
{
    public class CellChunk
    {
        public readonly Cell[,] cells;
        public Vector2Int chunkPosition;
        public Transform parent;

        public CellChunk(Cell[,] cells, Vector2Int chunkPosition)
        {
            this.cells = cells;
            this.chunkPosition = chunkPosition;
        }
    }
}
