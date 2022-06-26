using System;
using DG.Tweening;
using Sources.Runtime.Interfaces;
using Sources.Runtime.Utils;
using UnityEngine;
using VContainer;

namespace Sources.Runtime
{
    public class MonsterClickable : MonoBehaviour, IPoolObject, IDamageable
    {
        public event Action<IPoolObject> BecameUnused;
        public event Action Died;

        [SerializeField]
        private float _appearanceDuration;

        [SerializeField]
        private float _punchPower;

        [SerializeField]
        private float _punchDuration;

        [SerializeField]
        private float _dieDuration;

        private int _health;
        private GameConfigs _gameConfigs;
        private IReadonlyPlayerStats _playerStats;

        public int Health => _health;

        [Inject]
        private void Init(GameConfigs gameConfigs, IReadonlyPlayerStats playerStats)
        {
            _gameConfigs = gameConfigs;
            _health = gameConfigs.MonstersHealth;
            _playerStats = playerStats;
        }

        public void Shrink()
        {
            transform.DOComplete();
            var die = transform.DOScale(Vector3.zero, _dieDuration);
            die.onComplete += () =>
            {
                Disable();
                BecameUnused?.Invoke(this);
                Died = null;
            };
        }

        public void Enable()
        {
            UpdateHealth();
            transform.DOComplete();
            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one, _appearanceDuration);
            gameObject.SetActive(true);
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health > 0)
                return;
            
            Died?.Invoke();
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        private void UpdateHealth()
        {
            _health = _gameConfigs.MonstersHealth +
                      Mathf.FloorToInt(_gameConfigs.HealthPerSecond * Time.timeSinceLevelLoad);
        }

        private void OnMouseDown()
        {
            if (_health <= 0)
                return;
            TakeDamage(_playerStats.PlayerDamage);
            transform.DOComplete();
            transform.DOPunchScale(_punchPower * Vector3.one, _punchDuration);
        }
    }
}