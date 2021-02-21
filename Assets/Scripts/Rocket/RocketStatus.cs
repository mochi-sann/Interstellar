using UniRx;
using UnityEngine;

namespace Rocket
{
    public struct RocketStatus
    {
        public FloatReactiveProperty fuel;
        public FloatReactiveProperty maxFuel;

        public RocketStatus(RocketSetting rocketSetting)
        {
            maxFuel = new FloatReactiveProperty(rocketSetting.initialFuel);
            fuel = new FloatReactiveProperty(rocketSetting.initialFuel);
        }
    }
}
