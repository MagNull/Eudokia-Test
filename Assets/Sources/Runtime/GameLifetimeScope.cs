using Sources.Runtime;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField]
    private GameConfigs _gameConfigs;
    [SerializeField]
    private PlayerStats _playerStats;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_gameConfigs);
        builder.RegisterInstance(_playerStats).As<IReadonlyPlayerStats>().AsSelf();
    }
}
