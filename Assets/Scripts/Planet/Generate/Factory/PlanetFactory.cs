using Planet.Generate.Cell;
using UnityEngine;
using VContainer;

namespace Planet.Generate.Factory
{
    public interface IPlanetFactory
    {
        Transform CreatePlanet(CellChunk cellChunks);
    }
}
