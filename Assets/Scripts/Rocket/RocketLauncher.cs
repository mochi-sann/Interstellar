using System;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace Rocket
{
    public class RocketLauncher : IInitializable
    {
        private RocketLaunchSetting _launchSetting;
        private IInputProvider _inputProvider;
        private readonly RocketCollisionSender _collisionSender;

        private readonly Transform _rocketTransform;
        private readonly Rigidbody2D _rocketRigidbody;

        private RocketLauncher(IInputProvider inputProvider, RocketLaunchSetting launchSetting,
            RocketCollisionSender collisionSender, GameObject rocket)
        {
            _inputProvider = inputProvider;
            _launchSetting = launchSetting;
            _collisionSender = collisionSender;
            _rocketTransform = rocket.GetComponent<Transform>();
            _rocketRigidbody = rocket.GetComponent<Rigidbody2D>();
        }

        public void Initialize()
        {
            _inputProvider.DragStreamAsObservable()
                .TakeUntilDestroy(_rocketTransform)
                .WithLatestFrom(Observable.EveryFixedUpdate(), (touchPos, _) => touchPos)
                .Subscribe(touchPosition =>
                {
                    var diff = (touchPosition - _rocketTransform.position).normalized;
                    var axis = Vector3.Cross(_rocketTransform.up, diff);
                    var angle = Vector3.Angle(_rocketTransform.up, diff) * (axis.z < 0 ? -1 : 1);

                    angle = Mathf.Min(angle, _launchSetting.maxRot);
                    angle = Mathf.Max(angle, -_launchSetting.maxRot);

                    _rocketTransform.eulerAngles += new Vector3(0, 0, angle);
                    _rocketRigidbody.velocity = _rocketTransform.up * (_launchSetting.speed * Time.fixedDeltaTime);
                });
        }
    }
}
