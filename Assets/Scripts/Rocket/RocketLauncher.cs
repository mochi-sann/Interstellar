using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace Rocket
{
    public class RocketLauncher : IInitializable
    {
        private readonly RocketCollisionSender _collisionSender;
        private readonly IInputProvider _inputProvider;
        private readonly Rigidbody2D _rocketRigidbody;
        private readonly RocketSetting _rocketSetting;

        private readonly Transform _rocketTransform;
        private RocketStatus _rocketStatus;

        private RocketLauncher(IInputProvider inputProvider, RocketSetting rocketSetting, RocketStatus rocketStatus,
            RocketCollisionSender collisionSender, GameObject rocketgGameObject)
        {
            _inputProvider = inputProvider;
            _rocketSetting = rocketSetting;
            _rocketStatus = rocketStatus;

            _collisionSender = collisionSender;
            _rocketTransform = rocketgGameObject.GetComponent<Transform>();
            _rocketRigidbody = rocketgGameObject.GetComponent<Rigidbody2D>();
        }

        public void Initialize()
        {
            _inputProvider.DragStreamAsObservable()
                .TakeUntilDestroy(_rocketTransform)
                .WithLatestFrom(Observable.EveryFixedUpdate(), (touchPos, _) => touchPos)
                .Where(_ => _rocketStatus.fuel.Value > 0)
                .Subscribe(touchPosition =>
                {
                    var diff = (touchPosition - _rocketTransform.position).normalized;
                    var axis = Vector3.Cross(_rocketTransform.up, diff);
                    var angle = Vector3.Angle(_rocketTransform.up, diff) * (axis.z < 0 ? -1 : 1);

                    angle = Mathf.Min(angle, _rocketSetting.maxRot);
                    angle = Mathf.Max(angle, -_rocketSetting.maxRot);

                    _rocketTransform.eulerAngles += new Vector3(0, 0, angle);
                    _rocketRigidbody.velocity = _rocketTransform.up * (_rocketSetting.speed * Time.fixedDeltaTime);
                });
        }
    }
}
