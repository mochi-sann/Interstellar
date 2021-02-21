using Planet.Generate.Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace LifeTimeScope
{
    public class RootLifeTimeScope : LifetimeScope
    {

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("aaaa");
            builder.RegisterEntryPoint<MultiSceneManager>(Lifetime.Singleton);
        }
    }
}
