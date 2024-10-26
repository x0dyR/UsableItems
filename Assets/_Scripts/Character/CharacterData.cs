using System;

public class CharacterData
{
    private int _health;

    private float _speed;

    private Bullet _bulletPrefab;

    public CharacterData(int health, float speed, Bullet bulletPrefab)
    {
        _health = health;
        _speed = speed;
        _bulletPrefab = bulletPrefab;
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
        get => _speed; set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Speed cant be lower 0");

            _speed = value;
        }
    }
    public Bullet BulletPrefab
    {
        get => _bulletPrefab; set
        {
            if (_bulletPrefab == null)
                throw new ArgumentException("No bullet prefab");

            _bulletPrefab = value;
        }
    }
}
