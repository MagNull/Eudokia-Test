using System;

namespace Sources.Runtime.Utils
{
    public class Timer
    {
        public event Action<float> Ticked;
        private float _duration;
        private Action _action;
        private float _currentTick;

        public float Duration => _duration;

        public void Start(float duration, Action action, Action<float> onTick = null)
        {
            _duration = duration;
            if (duration <= 0)
            {
                action?.Invoke();
                return;
            }
            
            _action = action;
            _currentTick = duration;
            
            if (onTick != null)
                Ticked += onTick;
        }
        
        public void Tick(float deltaTime)
        {
            if(_currentTick <= 0)
                return;
            _currentTick -= deltaTime;
            
            Ticked?.Invoke(_currentTick);
            if (_currentTick <= 0)
                _action?.Invoke();
        }
    }
}