using Input;
using Rocket;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace LifeTimeScope
{
    public class RocketLifeTimeScope : LifetimeScope
    {
        [SerializeField] private GameObject rocket;
        [SerializeField] private RocketSetting rocketSetting;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.UseComponents(components =>
            {
                builder.RegisterInstance(rocket);
                builder.RegisterInstance(rocketSetting);

                builder.Register<RocketStatus>(Lifetime.Scoped);

                builder.RegisterComponentOnNewGameObject<InputProvider>(Lifetime.Scoped).AsImplementedInterfaces();
                builder.RegisterComponent(rocket.GetComponent<RocketCollisionSender>());
            });
            
            builder.RegisterEntryPoint<RocketLauncher>(Lifetime.Scoped);
            builder.RegisterEntryPoint<RocketFuelController>(Lifetime.Scoped);
        }
    }
}
