using UniRx;
using UnityEngine;
using VContainer.Unity;

public class PlanetAutoGenerateUser : IPostInitializable
{
    private GenerateSetting generateSetting;
    private CellChunkContainer cellChunkContainer;
    private PlayerChunkPositionObserver chunkPositionObservable;
    private PlanetGenerator planetGenerator;
    
    public PlanetAutoGenerateUser(GenerateSetting generateSetting,
        CellChunkContainer cellChunkContainer,
        PlayerChunkPositionObserver chunkPositionObservable,
        PlanetGenerator planetGenerator)
    {
        this.generateSetting = generateSetting;
        this.cellChunkContainer = cellChunkContainer;
        this.chunkPositionObservable = chunkPositionObservable;
        this.planetGenerator = planetGenerator;
        planetGenerator.Generate(Vector2Int.zero);

    }

    public void PostInitialize()
    {
        chunkPositionObservable.playerChunkPositionObservable.Subscribe(playerPosition =>
        {
            // Debug.Log(playerPosition);
        });
    }
}