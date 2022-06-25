using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class MonsterMovement : MonoBehaviour
{
    [SerializeField]
    private float _rotationBound = 60;
    [SerializeField]
    private float _collisionCheckCooldown = 1;
    private float _movementSpeed = 1;

    private float _lastCollisionCheck = 0;
    private Rigidbody _rigidbody;

    public void Init(float speed) => _movementSpeed = speed;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start() => _rigidbody.velocity =
        Quaternion.Euler(0, Random.Range(-360, 360), 0) * transform.forward * _movementSpeed;

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

    private void FixedUpdate() => _rigidbody.velocity = _rigidbody.velocity.normalized * _movementSpeed;

    private void LookAtMovement()
    {
        if (_rigidbody.velocity == Vector3.zero)
            return;
        transform.rotation = Quaternion.LookRotation(_rigidbody.velocity, Vector3.up);
    }
}