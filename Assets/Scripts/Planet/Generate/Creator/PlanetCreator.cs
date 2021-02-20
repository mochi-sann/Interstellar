using Planet.Generate.CreatePointer;
using UnityEngine;

namespace Planet.Generate.Creator
{
    public class PlanetCreator : IPlanetCreator
    {
        private readonly ICreatePointer _createPointer;
        private readonly GenerateSettings _generateSettings;

        public PlanetCreator(GenerateSettings generateSettings, ICreatePointer createPointer)
        {
            _generateSettings = generateSettings;
            _createPointer = createPointer;
        }

        public Transform Create(Cell.Cell cell)
        {
            var randomPlanet = _generateSettings.planets[Random.Range(0, 3)];

            var createPoint = _createPointer.Point(cell);

            var maxSize = cell.Size / 2;

            var size = Random.Range(randomPlanet.minSize, maxSize);

            var planet = Object.Instantiate(randomPlanet.prefab, createPoint,
                Quaternion.Euler(0, 0, Random.Range(0, 360f))).transform;

            planet.localScale = new Vector3(size, size, 1);

            return planet;
        }
    }
}
