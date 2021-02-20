using Input;
using Rocket;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace LifeTimeScope
{
    public class RocketLifeTimeScope : LifetimeScope
    {
        [SerializeField] private GameObject Rocket;
        [SerializeField] private RocketLaunchSetting _rocketLaunchSetting;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.UseComponents(components =>
            {
                builder.RegisterInstance(Rocket);
                builder.RegisterInstance(_rocketLaunchSetting);
                
                builder.RegisterComponentOnNewGameObject<InputProvider>(Lifetime.Scoped).AsImplementedInterfaces();
                builder.RegisterComponent(Rocket.GetComponent<RocketCollisionSender>());
            });

            builder.RegisterEntryPoint<RocketLauncher>(Lifetime.Scoped);

            // builder.UseEntryPoints(Lifetime.Scoped, entryPoints =>
            // {
            //     entryPoints.Add<RocketLauncher>();
            // });
        }
    }
}
