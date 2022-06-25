using System;
using Sources.Runtime.Interfaces;
using UnityEngine;
using VContainer;

namespace Sources.Runtime
{
    public class MonsterClickable : MonoBehaviour, IPoolObject
    {
        public event Action<IPoolObject> BecameUnused;
        private int _health;
        private GameConfigs _gameConfigs;

        [Inject]
        private void Init(GameConfigs gameConfigs)
        {
            _gameConfigs = gameConfigs;
            _health = gameConfigs.MonstersHealth;
        }

        public void Kill()
        {
            Disable();
            BecameUnused?.Invoke(this);
            BecameUnused = null;
        }

        public void Enable()
        {
            UpdateHealth();
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        private void UpdateHealth()
        {
            _health = _gameConfigs.MonstersHealth +
                      Mathf.FloorToInt(_gameConfigs.MonsterHealthPerSecond * Time.timeSinceLevelLoad);
        }

        private void OnMouseDown()
        {
            _health--;
            if (_health > 0)
                return;

            Kill();
        }
    }
}