using System.Collections.Generic;
using Planet.Generate.Cell;
using Planet.Generate.CreatePointer;
using Planet.Generate.Creator;
using UnityEngine;
using VContainer;

namespace Planet.Generate.Factory
{
    public class TestPlanetFactory : IPlanetFactory
    {
        private GenerateSettings _generateSettings;
        private IPlanetCreator _planetCreator;

        [Inject]
        public TestPlanetFactory(GenerateSettings generateSettings)
        {
            _generateSettings = generateSettings;
            _planetCreator = new PlanetCreator(_generateSettings, new PlanetCreatePointer());
        }

        public Transform CreatePlanet(CellChunk cellChunk)
        {
            var cellChunkTransform =
                new GameObject($"CellChunk{cellChunk.chunkPosition.ToString()}").GetComponent<Transform>();

            foreach (var cell in cellChunk.cells)
            {
                var planetObject = _planetCreator.Create(cell);
                planetObject.parent = cellChunkTransform;
            }

            cellChunk.parent = cellChunkTransform;

            return cellChunkTransform;
        }
    }
}
