using System;
using UnityEngine;

[Serializable]
public class CharacterData : EntityData
{
    private Bullet _bulletPrefab;

    public CharacterData(int health, float speed, Bullet bulletPrefab, Transform transform) : base(health, speed, transform)
    {
        _health = health;
        _speed = speed;
        _bulletPrefab = bulletPrefab;
        Transform = transform;
    }

    public Bullet BulletPrefab
    {
        get => _bulletPrefab;
        set
        {
            if (_bulletPrefab == null)
                throw new ArgumentException("No bullet prefab");

            _bulletPrefab = value;
        }
    }
}