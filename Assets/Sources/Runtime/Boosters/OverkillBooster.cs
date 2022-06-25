using System;
using Sources.Runtime.Utils;
using UnityEngine;

namespace Sources.Runtime
{
    [Serializable]
    public class OverkillBooster : IBooster
    {
        public event Action<float, float> Used;
        [SerializeField]
        private GameConfigs _gameConfigs;
        private Timer _timer;
        
        public OverkillBooster()
        {
            _timer = new Timer();
        }
        
        public void Use()
        {
            var monsters = GameObject.FindObjectsOfType<MonsterClickable>();
            foreach (var monster in monsters) 
                monster.Kill();
            Used?.Invoke(0, _gameConfigs.FreezeCooldown);
        }
    }
}