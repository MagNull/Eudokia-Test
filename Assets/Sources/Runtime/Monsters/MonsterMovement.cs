using System;
using System.Collections;
using System.Collections.Generic;
using Sources.Runtime;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class MonsterMovement : MonoBehaviour
{
    [SerializeField]
    private float _rotationBound = 60;
    [SerializeField]
    private float _collisionCheckCooldown = 1;
    private float _movementSpeed = 1;

    private Collider[] _colliders;
    private float _lastCollisionCheck;
    private Rigidbody _rigidbody;
    private GameConfigs _gameConfigs;
    private MonsterClickable _clickable;

    [Inject]
    private void Init(GameConfigs gameConfigs)
    {
        _gameConfigs = gameConfigs;
        _movementSpeed = gameConfigs.MonsterSpeed;
        _colliders = GetComponents<Collider>();
        enabled = true;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _clickable = GetComponent<MonsterClickable>();
        enabled = false;
    }

    private void RandomizeSpeed()
    {
        _rigidbody.velocity =
            Quaternion.Euler(0, Random.Range(-360, 360), 0) * transform.forward * _movementSpeed;
    }

    private void Update()
    {
        LookAtMovement();
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        if (Time.time - _lastCollisionCheck < _collisionCheckCooldown)
            return;

        _lastCollisionCheck = Time.time;

        var rotationAngle = Random.Range(-_rotationBound, _rotationBound);
        _rigidbody.velocity =
            Quaternion.Euler(0, rotationAngle, 0) * collisionInfo.GetContact(0).normal;
    }

    private void OnDied()
    {
        _movementSpeed = 0;
        foreach (var collider in _colliders) 
            collider.enabled = false;
    }

    private void UpdateSpeed()
    {
        _movementSpeed =
            _gameConfigs.MonsterSpeed + _gameConfigs.SpeedPerSecond * Time.timeSinceLevelLoad;
        _movementSpeed = Mathf.Clamp(_movementSpeed, 0, _gameConfigs.MaxMonsterSpeed);
    }

    private void OnEnable()
    {
        _clickable.Died += OnDied;
        UpdateSpeed();
        RandomizeSpeed();
        foreach (var collider in _colliders) 
            collider.enabled = true;
    }

    private void OnDisable()
    {
        _clickable.Died += OnDied;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _rigidbody.velocity.normalized * _movementSpeed;
    }

    private void LookAtMovement()
    {
        if (_rigidbody.velocity == Vector3.zero)
            return;

        transform.rotation = Quaternion.LookRotation(_rigidbody.velocity, Vector3.up);
    }
}