using System;
using UnityEngine;

public class EntityData
{
    [field: SerializeField] protected int _health;
    [field: SerializeField] protected float _speed;

    protected Transform _transform;

    public EntityData(int health, float speed, Transform transform)
    {
        Health = health;
        Speed = speed;
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

    public Transform Transform
    {
        get => _transform;
        set
        {
            if(value == null)
                throw new ArgumentNullException("Transform is null");

            _transform = value;
        }
    }
}
