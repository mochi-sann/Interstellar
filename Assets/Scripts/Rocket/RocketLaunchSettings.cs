using UnityEngine;

namespace Rocket
{
    [CreateAssetMenu(fileName = "RocketLaunchSetting", menuName = "Settings/RocketLaunchSetting")]
    public class RocketLaunchSetting : ScriptableObject
    {
        [SerializeField] public float speed;
        [SerializeField] public float maxRot;
        
    }
}
