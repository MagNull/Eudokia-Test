using System;
using Sources.Runtime.Utils;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Runtime
{
    [Serializable]
    public class FreezeBooster : IBooster
    {
        public event Action Used;
        public event Action Cooldowned;
        [SerializeField]
        private GameConfigs _gameConfigs;
        private Timer _timer;

        public FreezeBooster()
        {
            _timer = new Timer();
        }

        public void Use()
        {
            var monsterSpawner = GameObject.FindObjectOfType<MonstersSpawner>();
            monsterSpawner.FreezeSpawn();
            Used?.Invoke();
            _timer.Restart(_gameConfigs.FreezeCooldown, Cooldowned);
        }

        public void Update(float deltaTime)
        {
            _timer?.Tick(deltaTime);
        }
    }
}