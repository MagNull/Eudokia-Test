using System;
using Sources.Runtime.Utils;
using UnityEngine;
using VContainer;

namespace Sources.Runtime
{
    [Serializable]
    public class FreezeBooster : IBooster, IUpdateable
    {
        public event Action<float, float> Used;
        private GameConfigs _gameConfigs;
        private Timer _timer;

        [Inject]
        public void Init(GameConfigs gameConfigs)
        {
            _timer = new Timer();
            _gameConfigs = gameConfigs;
        }

        public void Use()
        {
            var monsterSpawner = GameObject.FindObjectOfType<MonstersSpawner>();
            monsterSpawner.StopSpawn();
            _timer.Start(_gameConfigs.FreezeDuration, monsterSpawner.StartSpawn);
            Used?.Invoke(_gameConfigs.FreezeDuration, _gameConfigs.FreezeCooldown);
        }

        public void Update(float deltaTime) => _timer.Tick(deltaTime);
    }
}