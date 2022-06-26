using System;
using UnityEngine;

namespace Sources.Runtime
{
    [Serializable]
    public class OverkillBooster : IBooster
    {
        public event Action<float, float> Used;
        [SerializeField]
        private GameConfigs _gameConfigs;

        public void Use()
        {
            var monsters = GameObject.FindObjectsOfType<MonsterClickable>();
            foreach (var monster in monsters) 
                monster.TakeDamage(monster.Health);
            Used?.Invoke(0, _gameConfigs.OverkillCooldown);
        }
    }
}