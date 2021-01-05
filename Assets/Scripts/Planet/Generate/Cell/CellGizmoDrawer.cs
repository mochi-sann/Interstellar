using UnityEditor;
using UnityEngine;
using VContainer;

public class CellGizmoDrawer : MonoBehaviour
{
    [Inject] private CellChunkContainer container;
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (!EditorApplication.isPlaying) return;

        foreach (var cellChunk in container.cellGroup)
        {
            Gizmos.color = Color.green;
            foreach (var cell in cellChunk.cells) Gizmos.DrawWireCube(cell.center, Vector2.one * cell.size);
            Gizmos.color = Color.red;

            var cellChunkSize = new Vector2(cellChunk.cellSize * cellChunk.cells.GetLength(0),
                cellChunk.cellSize * cellChunk.cells.GetLength(1));
            var cellChunkPosition = cellChunk.position * cellChunkSize + new Vector2(0, cellChunkSize.y / 2);

            Gizmos.DrawWireCube(cellChunkPosition, cellChunkSize);
        }
    }
#endif
}