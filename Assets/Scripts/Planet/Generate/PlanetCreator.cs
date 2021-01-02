using UnityEngine;
using VContainer;

public class PlanetCreator
{
    [Inject]
    private GenerateSetting generateSetting;

    public void Create(ref CellChunk cellChunk)
    {
        foreach (var cell in cellChunk.cells)
        {
            var Planet = Object.Instantiate(generateSetting.prefabs[Random.Range(0, generateSetting.prefabs.Length)], 
                cell.planet.position, Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f)));
            Planet.transform.localScale = new Vector2(cell.planet.size, cell.planet.size);

            Planet.GetComponent<SpriteRenderer>().material = generateSetting.prefabMaterial;


            cell.planet.gameObject = Planet;
        }
    }
}