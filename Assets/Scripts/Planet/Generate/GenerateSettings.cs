using UnityEngine;

namespace Planet.Generate
{
    [CreateAssetMenu(fileName = "GenerateSettings", menuName = "Settings/GenerateSettings")]
    public class GenerateSettings : ScriptableObject
    {
        public float cellSize;

        public int chunkCellRowCount;
        public int chunkCellColumnCount;
        public float CellChunkWidth => cellSize * chunkCellRowCount;
        public float CellChunkHeight => cellSize * chunkCellColumnCount;


        public int generateBorderRangeAtCellChunk;

        public Planet[] planets;
    }

    [System.Serializable]
    public struct Planet
    {
        public GameObject prefab;
        public Material material;
        public float minSize;
    }
}
