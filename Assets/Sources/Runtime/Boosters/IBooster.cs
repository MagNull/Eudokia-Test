using System;
using UnityEngine;

namespace Sources.Runtime
{
    public interface IBooster
    {
        public event Action Used;
        public event Action Cooldowned;
        
        void Use();

        void Update(float deltaTime);
    }
}