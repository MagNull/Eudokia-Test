using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Sources.Runtime
{
    [RequireComponent(typeof(Animator), typeof(MonsterClickable))]
    public class MonsterAnimator : MonoBehaviour
    {
        private readonly int _diedHash = Animator.StringToHash("Die");
        private Animator _animator;
        private MonsterClickable _clickable;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _clickable = GetComponent<MonsterClickable>();
        }

        private void OnEnable()
        {
            _clickable.Died += OnDied;
        }

        private void OnDisable()
        {
            _clickable.Died -= OnDied;
        }

        private void OnDied() => _animator.SetTrigger(_diedHash);
    }
}