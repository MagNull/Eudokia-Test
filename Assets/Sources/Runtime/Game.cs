using System;

namespace Sources.Runtime
{
    public class Game
    {
        public event Action<int> PointsChanged;
        public event Action Lost;
        private readonly int _monsterCountLoseCondition;
        private int _playerPoints;
        private int _monstersCount;


        public Game(int monsterCountLoseCondition)
        {
            _monsterCountLoseCondition = monsterCountLoseCondition;
        }

        public void OnMonsterSpawned()
        {
            _monstersCount++;
            CheckLoseCondition();
        }

        public void OnMonsterDied()
        {
            _playerPoints++;
            PointsChanged?.Invoke(_playerPoints);
            _monstersCount--;
        }

        private void CheckLoseCondition()
        {
            if(_monstersCount >= _monsterCountLoseCondition)
                Lost?.Invoke();
        }
    }
}