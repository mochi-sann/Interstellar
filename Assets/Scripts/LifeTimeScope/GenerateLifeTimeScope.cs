using VContainer.Unity;
using UnityEngine;
using Planet.Generate;
using Planet.Generate.Cell;
using Planet.Generate.Factory;
using Util;
using VContainer;

namespace LifeTimeScope
{
    public class GenerateLifeTimeScope : LifetimeScope
    {
        [SerializeField] private GenerateSettings generateSettings;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(generateSettings);
            builder.Register<CellChunkMap>(Lifetime.Scoped);
            builder.Register<CellInitializer>(Lifetime.Scoped);
            builder.Register<TestPlanetFactory>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<PlanetGenerator>(Lifetime.Scoped);

            //     builder.Register<CellInitializer>(Lifetime.Scoped);
            //     builder.Register<CellChunkContainer>(Lifetime.Scoped);
            //     builder.Register<PlanetCreatePointer>(Lifetime.Scoped);
            //     builder.Register<PlanetCreator>(Lifetime.Scoped);
            //     builder.Register<PlanetGenerator>(Lifetime.Scoped);
            //     builder.UseEntryPoints(Lifetime.Scoped, pointsBuilder =>
            //     {
            //         pointsBuilder.Add<PlayerChunkPositionObserver>().AsSelf();
            //         pointsBuilder.Add<PlanetAutoGenerateUser>();
            // });
        }
    }
}
