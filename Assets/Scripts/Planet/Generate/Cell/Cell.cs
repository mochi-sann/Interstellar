using UnityEngine;

public class Cell
{
    public Planet planet;

    public Cell(Vector2 min, Vector2 max)
    {
        this.min = min;
        this.max = max;
    }

    public Vector2 min { get; }
    public Vector2 max { get; }
    public Vector2 center => (min + max) / 2;
    public float size => Mathf.Abs(max.x - min.x);

    public void DestroyCell()
    {
        planet.Destroy();
        planet = null;
    }
}