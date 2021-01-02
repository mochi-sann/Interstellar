using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GenerateLifeTimeScope : LifetimeScope
{
    [SerializeField] private GenerateSetting generateSetting;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(generateSetting);
        builder.Register<CellChunkContainer>(Lifetime.Scoped);
        builder.Register<CellInitializer>(Lifetime.Scoped);
        builder.Register<CellChunkContainer>(Lifetime.Scoped);
        builder.Register<PlanetCreatePointer>(Lifetime.Scoped);
        builder.Register<PlanetCreator>(Lifetime.Scoped);
        builder.Register<PlanetGenerator>(Lifetime.Scoped);
        builder.UseEntryPoints(Lifetime.Scoped, pointsBuilder =>
        {
            pointsBuilder.Add<PlayerChunkPositionObserver>().AsSelf();
            pointsBuilder.Add<PlanetAutoGenerateUser>();
        });
    }
}