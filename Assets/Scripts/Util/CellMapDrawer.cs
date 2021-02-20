using Planet.Generate;
using Planet.Generate.Cell;
using UnityEditor;
using UnityEngine;
using VContainer;

namespace Util
{
    public class CellMapDrawer : MonoBehaviour
    {
        [Inject] private CellChunkMap _cellChunkMap;
        [Inject] private GenerateSettings _generateSettings;
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (!EditorApplication.isPlaying) return;

            foreach (var cellChunk in _cellChunkMap.cellChunks)
            {
                Gizmos.color = Color.green;
                foreach (var cell in cellChunk.Value.cells) Gizmos.DrawWireCube(cell.Center, Vector2.one * cell.Size);

                Gizmos.color = Color.red;
                var cellChunkSize = new Vector2(_generateSettings.cellSize * _generateSettings.chunkCellRowCount,
                    _generateSettings.cellSize * _generateSettings.chunkCellColumnCount);
                var cellChunkPosition =
                    cellChunk.Value.chunkPosition * cellChunkSize + new Vector2(0, cellChunkSize.y / 2);

                Gizmos.DrawWireCube(cellChunkPosition, cellChunkSize);
            }
        }
#endif
    }
}
