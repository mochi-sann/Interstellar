using Planet.Generate.CreatePointer;
using UnityEngine;

namespace Planet.Generate.Creator
{
    interface IPlanetCreator
    {
        Transform Create(Cell.Cell cell);
    }
}
