using System;

namespace Sources.Runtime.Utils
{
    public interface IDamageable
    {
        public event Action Died;

        void TakeDamage(int damage);
    }
}