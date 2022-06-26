using System;
using Sources.Runtime.Utils;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Runtime
{
    [Serializable]
    public class FreezeBooster : IBooster
    {
        public event Action<float, float> Used;
        [SerializeField]
        private GameConfigs _gameConfigs;

        public void Use()
        {
            var monsterSpawner = GameObject.FindObjectOfType<MonstersSpawner>();
            monsterSpawner.FreezeSpawn();
            Used?.Invoke(_gameConfigs.FreezeDuration, _gameConfigs.FreezeCooldown);
        }
    }
}