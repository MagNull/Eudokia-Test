using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Sources.Runtime
{
    public class MonstersFactory : MonoBehaviour
    {
        [SerializeField]
        private MonsterClickable _monsterPrefab;
        private GameConfigs _configs;
        private IObjectResolver _objectResolver;

        [Inject]
        private void Init(GameConfigs configs, IObjectResolver resolver)
        {
            _configs = configs;
            _objectResolver = resolver;
        }

        public MonsterClickable Create()
        {
            var monster = _objectResolver.Instantiate(_monsterPrefab);
            _objectResolver.InjectGameObject(monster.gameObject);
            return monster;
        }
    }
}