using UnityEngine;

namespace Sources.Runtime
{
    public class MonstersFactory : MonoBehaviour
    {
        [SerializeField]
        private GameConfigs _configs;
        [SerializeField]
        private MonsterClickable _monsterPrefab;

        public MonsterClickable Create()
        {
            var monster = Instantiate(_monsterPrefab);
            monster.Init(_configs.MonstersHealth);
            monster.GetComponent<MonsterMovement>().Init(_configs.MonsterSpeed);
            return monster;
        }
    }
}