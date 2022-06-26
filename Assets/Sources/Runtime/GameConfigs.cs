using UnityEngine;

namespace Sources.Runtime
{
    [CreateAssetMenu(fileName = "Config", menuName = "Game Config")]
    public class GameConfigs : ScriptableObject
    {
        [Header("Start configs")]
        [SerializeField]
        private int _monsterCountLoseCondition;
        [SerializeField]
        private int _monstersHealth;
        [SerializeField]
        private float _monsterSpeed;
        [SerializeField]
        private float _maxMonsterSpeed;
        [SerializeField]
        private float _spawnInterval;
        [SerializeField]
        private float _minSpawnInterval;
        
        [Header("Difficulty configs")]
        [SerializeField]
        private float _healthPerSecond;
        [SerializeField]
        private float _speedPerSecond;
        [SerializeField]
        private float _intervalReductionPerSecond;

        [Header("Freeze booster config")]
        [SerializeField]
        private float _freezeDuration;
        [SerializeField]
        private float _freezeCooldown;
        [Header("Overkill booster config")]
        [SerializeField]
        private float _overkillCooldown;

        public int MonstersHealth => _monstersHealth;

        public float MonsterSpeed => _monsterSpeed;

        public float SpawnInterval => _spawnInterval;

        public float FreezeDuration => _freezeDuration;

        public int MonsterCountLoseCondition => _monsterCountLoseCondition;

        public float FreezeCooldown => _freezeCooldown;

        public float OverkillCooldown => _overkillCooldown;

        public float HealthPerSecond => _healthPerSecond;

        public float SpeedPerSecond => _speedPerSecond;

        public float IntervalReductionPerSecond => _intervalReductionPerSecond;

        public float MinSpawnInterval => _minSpawnInterval;

        public float MaxMonsterSpeed => _maxMonsterSpeed;
    }
}