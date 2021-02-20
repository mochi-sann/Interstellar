using UnityEngine;

namespace Planet.Generate.Cell
{
    public class Cell
    {
        private Vector2 _min;
        private Vector2 _max;

        public Vector2 min { get; }
        public Vector2 max { get; }

        public Vector2 Center => (min + max) / 2;
        public float Size => Mathf.Abs(max.x - min.x);

        public Cell(Vector2 min, Vector2 max)
        {
            this.min = min;
            this.max = max;
        }
    }
}
