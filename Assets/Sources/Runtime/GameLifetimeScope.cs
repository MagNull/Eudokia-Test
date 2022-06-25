using Sources.Runtime;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField]
    private GameConfigs _gameConfigs;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_gameConfigs);
    }
}
