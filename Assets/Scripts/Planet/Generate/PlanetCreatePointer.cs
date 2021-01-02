using UnityEngine;

public class PlanetCreatePointer
{
    private readonly float maxSizeRatio = 1.8f;
    private readonly float minSizeRatio = 4.0f;

    public void SetCreatePoint(ref CellChunk cellChunk)
    {
        foreach (var cell in cellChunk.cells)
        {
            var objectSize = Random.Range(cell.size / minSizeRatio, cell.size / maxSizeRatio);

            var generateRange = (cell.size - objectSize) / 2;

            var xPos = Random.Range(cell.center.x - generateRange, cell.center.x + generateRange);
            var yPos = Random.Range(cell.center.y - generateRange, cell.center.y + generateRange);

            cell.planet = new Planet(new Vector2(xPos, yPos), objectSize);
        }
    }
}
