using System;
using Sources.Runtime.Interfaces;
using UnityEngine;

namespace Sources.Runtime
{
    public class MonsterClickable : MonoBehaviour, IPoolObject
    {
        public event Action<IPoolObject> BecameUnused;
        private int _health;

        public void Init(int health) => _health = health;

        public void Kill()
        {
            Disable();
            BecameUnused?.Invoke(this);
            BecameUnused = null;
        }
        
        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        private void OnMouseDown()
        {
            _health--;
            if (_health > 0)
                return;

            Kill();
        }
    }
}