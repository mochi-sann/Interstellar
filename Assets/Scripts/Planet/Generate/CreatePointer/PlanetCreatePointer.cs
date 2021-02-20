using UnityEngine;
using VContainer;

namespace Planet.Generate.CreatePointer
{
    public class PlanetCreatePointer : ICreatePointer
    {
        public Vector2 Point(Cell.Cell cell)
        {
            var generateRange = cell.Size / 2;

            var xPos = Random.Range(cell.Center.x - generateRange, cell.Center.x + generateRange);
            var yPos = Random.Range(cell.Center.y - generateRange, cell.Center.y + generateRange);
            
            return new Vector2(xPos, yPos);
        }
    }
}
