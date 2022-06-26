using System;

namespace Sources.Runtime
{
    public interface IBooster
    {
        public event Action<float, float> Used;
        
        void Use();
    }
}