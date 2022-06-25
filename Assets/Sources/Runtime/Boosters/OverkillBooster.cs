using System;
using Sources.Runtime.Utils;
using UnityEngine;

namespace Sources.Runtime
{
    [Serializable]
    public class OverkillBooster : IBooster
    {
        public event Action Used;
        public event Action Cooldowned;
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
            Used?.Invoke();
            _timer.Restart(_gameConfigs.OverkillCooldown, Cooldowned);
        }

        public void Update(float deltaTime) => _timer?.Tick(deltaTime);
    }
}