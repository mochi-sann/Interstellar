using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Rocket
{
    public class RocketFuelController : IInitializable
    {
        private readonly RocketCollisionSender _collisionSender;
        private readonly IInputProvider _inputProvider;
        private readonly RocketSetting _rocketSetting;
        private readonly RocketStatus _rocketStatus;

        [Inject]
        public RocketFuelController(RocketStatus rocketStatus, RocketSetting rocketSetting,
            IInputProvider inputProvider, RocketCollisionSender collisionSender)
        {
            _rocketStatus = rocketStatus;
            _rocketSetting = rocketSetting;
            _inputProvider = inputProvider;
            _collisionSender = collisionSender;
        }

        public void Initialize()
        {
            _inputProvider.DragStreamAsObservable()
                .WithLatestFrom(Observable.EveryFixedUpdate(), (tPos, _) => Unit.Default)
                .Subscribe(_ =>
                {
                    _rocketStatus.fuel.Value -= Time.fixedDeltaTime * _rocketSetting.fuelDecreaseSpeed;
                    _rocketStatus.fuel.Value = Mathf.Clamp(_rocketStatus.fuel.Value, 0, _rocketStatus.maxFuel.Value);
                });

            _collisionSender.TriggerStayAsObservable.Subscribe(col =>
            {
                _rocketStatus.fuel.Value += Time.deltaTime * _rocketSetting.fuelIncreaseSpeed;
                _rocketStatus.fuel.Value = Mathf.Clamp(_rocketStatus.fuel.Value, 0, _rocketStatus.maxFuel.Value);
            });
        }
    }
}
