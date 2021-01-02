using UnityEngine;
using VContainer;

public class PlanetGenerator
{
    private CellChunkContainer cellChunkContainer;
    private CellInitializer cellInitializer;
    private PlanetCreator planetCreator;
    private PlanetCreatePointer planetPointer;

    [Inject]
    public PlanetGenerator(CellChunkContainer _cellChunkContainer,
        CellInitializer _cellInitializer,
        PlanetCreatePointer _planetCreatePointer,
        PlanetCreator _planetCreator)
    {
        this.cellChunkContainer = _cellChunkContainer;
        this.cellInitializer = _cellInitializer;
        this.planetPointer = _planetCreatePointer;
        this.planetCreator = _planetCreator;
    }

    public void Generate(Vector2Int generateChunkPosition)
    {
        var cellChunk = cellInitializer.Initialize(generateChunkPosition);

        planetPointer.SetCreatePoint(ref cellChunk);
        planetCreator.Create(ref cellChunk);

        cellChunkContainer.AddCellGroup(cellChunk);
    }
}