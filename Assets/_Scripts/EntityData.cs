using System;
using UnityEngine;

public class EntityData
{
    public event Action<int> HealthChanged;
    public event Action<float> SpeedChanged;

    private int _health;
    private float _speed;
    
    private Transform _transform;

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
            HealthChanged?.Invoke(_health);
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
            SpeedChanged?.Invoke(_speed);
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
