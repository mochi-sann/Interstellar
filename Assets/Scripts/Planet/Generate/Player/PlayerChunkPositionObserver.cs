using System;
using UniRx;
using UnityEngine;
using VContainer.Unity;

public class PlayerChunkPositionObserver : IInitializable
{
    private GenerateSetting generateSetting;
    private Transform playerTransform;
    private Vector2Int currentPosition;

    public IObservable<Vector2Int> playerChunkPositionObservable;

    public PlayerChunkPositionObserver(GenerateSetting generateSetting)
    {
        this.generateSetting = generateSetting;
    }


    public void Initialize()
    {
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        if (playerTransform == null) throw new NullReferenceException("Player GameObject");

        playerChunkPositionObservable = playerTransform
            .ObserveEveryValueChanged(t => (Vector2) t.position)
            .Select(position =>
            {
                Debug.Log(position / generateSetting.ChunkSize);
                return new Vector2Int(Mathf.FloorToInt(position.x / generateSetting.ChunkSize),
                    Mathf.FloorToInt(position.y / generateSetting.ChunkSize));
            });
    }

    public static Vector2Int ToVector2Int(Vector2 vector2)
    {
        return new Vector2Int((int) vector2.x, (int) vector2.y);
    }
}