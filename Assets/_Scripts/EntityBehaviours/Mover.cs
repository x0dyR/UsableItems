using UnityEngine;

public class Mover
{
    private const float DeadZone = 0.1f;

    private Transform _transform;

    private EntityData _entityData;

    private float _rotationAngleSpeed;

    public Mover(Transform transform, EntityData entityData, float roatationAngleSpeed)
    {
        _transform = transform;
        _entityData = entityData;
        _rotationAngleSpeed = roatationAngleSpeed;
    }

    public void ProcessMove(Vector3 direction)
    {
        if (direction.sqrMagnitude < DeadZone * DeadZone)
            return;

        _transform.position += direction * _entityData.Speed * Time.deltaTime;
        _transform.forward = Vector3.Lerp(_transform.position, direction, _rotationAngleSpeed);
    }
}
