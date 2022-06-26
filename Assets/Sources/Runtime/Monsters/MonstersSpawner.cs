using System;
using System.Collections;
using System.Collections.Generic;
using Sources.Runtime.Utils;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace Sources.Runtime
{
    public class MonstersSpawner : MonoBehaviour
    {
        public event Action<MonsterClickable> MonsterSpawned;
        [SerializeField]
        private MonstersFactory _monstersFactory;
        private GameConfigs _gameConfigs;
        [SerializeField]
        private Transform _spawnZone;
        private Coroutine _spawnCoroutine;

        private ObjectPool<MonsterClickable> _monstersPool;

        public void StopSpawn() => StopAllCoroutines();

        public void StartSpawn() => _spawnCoroutine = StartCoroutine(Spawning());
        
        [Inject]
        private void Init(GameConfigs configs)
        {
            _gameConfigs = configs;
        }

        private void Awake() => _monstersPool =
            new ObjectPool<MonsterClickable>(_gameConfigs.MonsterCountLoseCondition, _monstersFactory.Create);

        private void Start() => StartSpawn();

        private IEnumerator Spawning()
        {
            while (true)
            {
                var newSpawnInterval = _gameConfigs.SpawnInterval -
                                       _gameConfigs.IntervalReductionPerSecond * Time.timeSinceLevelLoad;
                newSpawnInterval = Mathf.Clamp(newSpawnInterval,_gameConfigs.MinSpawnInterval, Mathf.Infinity);
                yield return new WaitForSeconds(newSpawnInterval);
                SpawnMonster();
            }
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