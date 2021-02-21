using Rocket;
using UnityEngine;
using VContainer;
using UniRx;
using UnityEngine.UI;

namespace Planet.Generate.UI
{
    public class FuelGaugeViewer : MonoBehaviour
    {
        [Inject] private RocketStatus _rocketStatus;

        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
            _rocketStatus.fuel.Subscribe(fuel => { _image.fillAmount = fuel / _rocketStatus.maxFuel.Value; });
        }
    }
}
