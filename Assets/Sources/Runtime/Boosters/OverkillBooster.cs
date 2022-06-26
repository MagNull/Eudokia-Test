using System;
using UnityEngine;
using VContainer;

namespace Sources.Runtime
{
    [Serializable]
    public class OverkillBooster : IBooster
    {
        public event Action<float, float> Used;
        private GameConfigs _gameConfigs;
        
        [Inject]
        public void Init(GameConfigs gameConfigs)
        {
            _gameConfigs = gameConfigs;
        }

        public void Use()
        {
            var monsters = GameObject.FindObjectsOfType<MonsterClickable>();
            foreach (var monster in monsters) 
                monster.TakeDamage(monster.Health);
            Used?.Invoke(0, _gameConfigs.OverkillCooldown);
        }
    }
}