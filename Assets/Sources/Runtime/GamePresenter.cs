using UnityEngine;
using VContainer;

namespace Sources.Runtime
{
    public class GamePresenter : MonoBehaviour
    {
        private GameConfigs _gameConfigs;
        private GameView _gameView;
        private Game _game;
        private MonstersSpawner _monstersSpawner;

        [Inject]
        private void Init(GameConfigs configs)
        {
            _gameConfigs = configs;
        }
        
        private void Awake()
        {
            _gameView = FindObjectOfType<GameView>();
            _game = new Game(_gameConfigs.MonsterCountLoseCondition);
            var spawner = FindObjectOfType<MonstersSpawner>();
            spawner.MonsterSpawned += OnMonsterSpawned;
            
            _game.PointsChanged += _gameView.OnPointsChanged;
            _game.Lost += _gameView.OnLost;
        }

        private void OnMonsterSpawned(MonsterClickable monster)
        {
            _game.OnMonsterSpawned();
            monster.BecameUnused += _game.OnMonsterDestroyed;
        }
    }
}