using System;
using UnityEngine;

public class EntityData
{
    private int _health;
    private float _speed;

    private Bullet _bulletPrefab;
    
    private Transform _transform;

    public EntityData(int health, float speed, Bullet bulletPrefab,Transform transform)
    {
        Health = health;
        Speed = speed;
        _bulletPrefab = bulletPrefab;
        _transform = transform;
    }

    public int Health
    {
        get => _health;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Health cant be lower 0");

            _health = value;
        }
    }

    public float Speed
    {
        get => _speed;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Speed cant be lower 0");

            _speed = value;
        }
    }

    public Bullet BulletPrefab
    {
        get => _bulletPrefab;
        set
        {
            if (value == null)
                throw new ArgumentNullException("Bullet is null");

            _bulletPrefab = value;
        }
    }

    public Transform Transform
    {
        get => _transform;
        set
        {
            if (value == null)
                throw new ArgumentNullException("Transform is null");

            _transform = value;
        }
    }
}
