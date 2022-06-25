using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Runtime.Interfaces;

namespace Sources.Runtime.Utils
{
    public class ObjectPool<T> where T : IPoolObject
    {
        private readonly Stack<IPoolObject> _pool;
        private readonly Func<T> _factoryMethod;

        public ObjectPool(int capacity, Func<T> factoryMethod)
        {
            _pool = new Stack<IPoolObject>();
            _factoryMethod = factoryMethod;
            FillPool(capacity);
        }

        public T Get()
        {
            T result;
            if (_pool.Any())
            {
                result = (T)_pool.Pop();
            }
            else
            {
                result = _factoryMethod.Invoke();
                result.BecameUnused += OnObjectBecameUnused;
            }
            
            result.Enable();
            return result;
        }

        private void FillPool(int capacity)
        {
            for (var i = 0; i < capacity; i++)
            {
                var obj = _factoryMethod.Invoke();
                obj.Disable();
                _pool.Push(obj);
                obj.BecameUnused += OnObjectBecameUnused;
            }
        }

        private void OnObjectBecameUnused(IPoolObject poolObject)
        {
            _pool.Push(poolObject);
        }
    }
}