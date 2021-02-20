using Planet.Generate.Cell;
using UnityEngine;

namespace Planet.Generate.CreatePointer
{
    public interface ICreatePointer
    {
        Vector2 Point(Cell.Cell cell);
    }
}
