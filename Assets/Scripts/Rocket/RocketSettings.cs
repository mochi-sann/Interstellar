using UnityEngine;

namespace Rocket
{
    [CreateAssetMenu(fileName = "RocketSettings", menuName = "Settings/RocketSettings")]
    public class RocketSetting : ScriptableObject
    {
        public float initialFuel;
        public float fuelIncreaseSpeed;
        public float fuelDecreaseSpeed;

        public float speed;
        public float maxRot;
    }
}
