using UnityEngine;
using VContainer;
using VContainer.Unity;

public class RootLifeTimeScope : LifetimeScope
{
    [SerializeField] private GameObject Player;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentOnNewGameObject<InputProvider>(Lifetime.Singleton).AsImplementedInterfaces();
        builder.RegisterEntryPoint<PlayerMover>(Lifetime.Singleton);
        builder.RegisterInstance<PlayerCollisionSender>(Player.GetComponent<PlayerCollisionSender>());
    }
}
