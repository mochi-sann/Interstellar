using Planet.Generate.Cell;
using Planet.Generate.Factory;
using UnityEngine;
using VContainer;

namespace Planet.Generate
{
    public class PlanetGenerator
    {
        private CellInitializer _cellInitializer;
        private IPlanetFactory _planetFactory;

        private CellChunkMap _cellChunkMap;

        [Inject]
        public PlanetGenerator(CellInitializer cellInitializer, IPlanetFactory planetFactory,
            CellChunkMap cellCellChunkMap)
        {
            _cellInitializer = cellInitializer;
            _planetFactory = planetFactory;
            _cellChunkMap = cellCellChunkMap;
        }

        public void Generate(Vector2Int chunkPosition)
        {
            var cellChunk = _cellInitializer.Initialize(chunkPosition);
            _planetFactory.CreatePlanet(cellChunk);

            _cellChunkMap.AddChunk(cellChunk);
        }
    }
}
