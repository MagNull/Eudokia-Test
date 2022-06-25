using UnityEngine;

namespace Sources.Runtime
{
    public class GamePresenter : MonoBehaviour
    {
        [SerializeField]
        private int _monsterCountLoseCondition = 10;
        private GameView _gameView;
        private Game _game;
        private MonstersSpawner _monstersSpawner;

        private void Awake()
        {
            _gameView = FindObjectOfType<GameView>();
            _game = new Game(_monsterCountLoseCondition);
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