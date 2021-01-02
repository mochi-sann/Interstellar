using UnityEngine;

public class Planet
{
    public GameObject gameObject;
    public Vector2 position;
    public float size;

    public Planet(Vector2 position, float size)
    {
        this.position = position;
        this.size = size;
    }

    public void Destroy()
    {
        Object.Destroy(gameObject);
    }
}