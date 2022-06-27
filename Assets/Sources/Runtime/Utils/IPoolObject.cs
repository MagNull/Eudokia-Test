using System;

namespace Sources.Runtime.Utils
{
    public interface IPoolObject
    {
        public event Action<IPoolObject> BecameUnused;
        
        void Enable();
        void Disable();
    }
}