using UnityEngine;

public class Mover
{
    private const float DeadZone = 0.1f;

    private Transform _transform;

    private float _speed;

    private float _rotationAngleSpeed;

    public Mover(Transform transform, float speed,float roatationAngleSpeed)
    {
        _transform = transform;
        _speed = speed;
        _rotationAngleSpeed = roatationAngleSpeed;
    }

    public void ProcessMove(Vector3 direction)
    {
        if (direction.sqrMagnitude > DeadZone * DeadZone)
        {
            _transform.position += direction * _speed * Time.deltaTime;
            _transform.forward = Vector3.Lerp(_transform.position, direction, _rotationAngleSpeed);
        }
    }
}
