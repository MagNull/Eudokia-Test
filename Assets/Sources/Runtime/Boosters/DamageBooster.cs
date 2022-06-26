using System;
using Sources.Runtime.Utils;
using VContainer;

namespace Sources.Runtime
{
    [Serializable]
    public class DamageBooster : IBooster, IUpdateable
    {
        public event Action<float, float> Used;
        private PlayerStats _playerStats;
        private GameConfigs _gameConfigs;
        private Timer _timer;

        [Inject]
        public void Init(GameConfigs gameConfigs, PlayerStats playerStats)
        {
            _timer = new Timer();
            _gameConfigs = gameConfigs;
            _playerStats = playerStats;
        }

        public void Use()
        {
            _playerStats.IncreaseDamage(_gameConfigs.DamageAmplify);
            _timer.Start(_gameConfigs.FreezeDuration, () => _playerStats.ReduceDamage(_gameConfigs.DamageAmplify));
            Used?.Invoke(_gameConfigs.DamageDuration, _gameConfigs.DamageCooldown);
        }

        public void Update(float deltaTime)
        {
            _timer.Tick(deltaTime);
        }
    }
}