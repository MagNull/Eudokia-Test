using System;
using System.Collections;
using System.Collections.Generic;
using Sources.Runtime.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sources.Runtime
{
    public class MonstersSpawner : MonoBehaviour
    {
        public event Action<MonsterClickable> MonsterSpawned;
        [SerializeField]
        private MonstersFactory _monstersFactory;
        [SerializeField]
        private GameConfigs _gameConfigs;
        [SerializeField]
        private Transform _spawnZone;
        private Coroutine _spawnCoroutine;
        
        private ObjectPool<MonsterClickable> _monstersPool;

        public void FreezeSpawn() => StartCoroutine(PauseSpawn(_gameConfigs.FreezeDuration));

        private void Awake() => _monstersPool =
            new ObjectPool<MonsterClickable>(_gameConfigs.MonsterCountLoseCondition, _monstersFactory.Create);

        private void Start() => _spawnCoroutine = StartCoroutine(Spawning());

        private IEnumerator Spawning()
        {
            while (true)
            {
                yield return new WaitForSeconds(_gameConfigs.SpawnInterval);
                SpawnMonster();
            }
        }

        private IEnumerator PauseSpawn(float duration)
        {
            StopCoroutine(_spawnCoroutine);
            yield return new WaitForSeconds(duration);
            _spawnCoroutine = StartCoroutine(Spawning());
        }

        private void SpawnMonster()
        {
            var monster = _monstersPool.Get();
            var randomPosition =
                new Vector3(Random.Range(_spawnZone.position.x - _spawnZone.localScale.x / 2,
                        _spawnZone.position.x + _spawnZone.localScale.x / 2), _spawnZone.position.y,
                    Random.Range(_spawnZone.position.y - _spawnZone.localScale.y / 2,
                        _spawnZone.position.y + _spawnZone.localScale.y / 2));
            monster.transform.position = randomPosition;
            MonsterSpawned?.Invoke(monster);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_spawnZone.position, _spawnZone.localScale);
        }
    }
}