using UnityEngine;
using VContainer;

namespace Planet.Generate
{
    public class PlanetGeneratorTest : MonoBehaviour
    {
        [Inject]private PlanetGenerator _planetGenerator;
        
        private void Start()
        {
            _planetGenerator.Generate(new Vector2Int(0, 1));
        }
    }
}
