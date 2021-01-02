using UnityEngine;

[CreateAssetMenu(fileName = "GenerateSetting", menuName = "Interstellar/GenerateSetting")]
public class GenerateSetting : ScriptableObject
{
    public float cellSize;
    public int chunkCellRowCount;
    public int chunkCellHeight;

    public GameObject[] prefabs;
    public Material prefabMaterial;

    public int generateBorderRangeAtCell;

    public float ChunkSize => cellSize * chunkCellRowCount;
}
