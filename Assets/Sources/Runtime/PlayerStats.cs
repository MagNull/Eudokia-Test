using System;
using UnityEngine;

namespace Sources.Runtime
{
    [Serializable]
    public class PlayerStats : IReadonlyPlayerStats
    {
        [SerializeField]
        private float _clickDamage;
        public int ClickDamage => Mathf.FloorToInt(_clickDamage);

        public void IncreaseDamage(float value) => _clickDamage += value;

        public void ReduceDamage(float value) => _clickDamage -= value;
    }

    public interface IReadonlyPlayerStats
    {
        public int ClickDamage { get; }
    }
}