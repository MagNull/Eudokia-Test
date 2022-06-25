using System;

namespace Sources.Runtime.Utils
{
    public class Timer
    {
        private float _duration;
        private Action _action;
        private float _currentTick;

        public Timer(float duration, Action action) => Restart(duration, action);

        public Timer(){}

        public void Restart(float duration, Action action)
        {
            _duration = duration;
            _action = action;
            _currentTick = duration;
        }
        
        public void Tick(float deltaTime)
        {
            if(_currentTick <= 0)
                return;
            _currentTick -= deltaTime;
            if (_currentTick <= 0)
                _action?.Invoke();
        }
    }
}