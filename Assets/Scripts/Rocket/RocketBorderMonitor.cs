using Planet.Generate;
using Planet.Generate.Cell;
using UniRx;
using UnityEngine;
using VContainer;

namespace Rocket
{
    public class RocketBorderMonitor : MonoBehaviour
    {
        [Inject] private CellChunkMap _cellChunkMap;

        private readonly ReactiveProperty<Vector2Int> _currenntChunkPosition =
            new ReactiveProperty<Vector2Int>(Vector2Int.zero);

        [Inject] private GenerateSettings _generateSettings;
        [Inject] private PlanetGenerator _planetGenerator;

        private void Start()
        {
            GetComponent<Transform>().ObserveEveryValueChanged(t => t.position)
                .Subscribe(position =>
                {
                    _currenntChunkPosition.Value = Vector2Int.FloorToInt(new Vector2(
                        (position.x + _generateSettings.CellChunkWidth / 2) / _generateSettings.CellChunkWidth
                        , position.y / _generateSettings.CellChunkHeight));
                });

            _currenntChunkPosition
                .Select(position => position + Vector2Int.up)
                .Where(gen_position => !_cellChunkMap.ChunkExist(gen_position))
                .Subscribe(gen_position => _planetGenerator.Generate(gen_position));

            _currenntChunkPosition
                .Select(position => position + new Vector2Int(0, 2))
                .Where(gen_position => !_cellChunkMap.ChunkExist(gen_position))
                .Subscribe(gen_position => _planetGenerator.Generate(gen_position));


            _currenntChunkPosition
                .Select(position => position - new Vector2Int(0, 2))
                .Subscribe(delete_position => _cellChunkMap.DeleteChunk(delete_position));
        }

        // private bool CheckExceededBorder(Vector2 position)
        // {
        //     var borderPositionY = _generateSettings.cellSize * (_generateSettings.generateBorderRangeAtCellChunk - 1);
        //     return position.y > borderPositionY +
        //     return false;
        // }
    }
}
