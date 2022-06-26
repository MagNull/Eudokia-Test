using System;
using UnityEngine;

namespace Sources.Runtime
{
    [Serializable]
    public class PlayerStats : IReadonlyPlayerStats
    {
        [SerializeField]
        private float _clickDamage;
        public int PlayerDamage => Mathf.FloorToInt(_clickDamage);
    }

    public interface IReadonlyPlayerStats
    {
        public int PlayerDamage { get; }
    }
}