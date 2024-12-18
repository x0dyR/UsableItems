using UnityEngine;

public class Mover
{
    private const float DeadZone = 0.1f;

    private Transform _transform;

    private EntityData _entityData;

    public Mover(Transform transform, EntityData entityData)
    {
        _transform = transform;
        _entityData = entityData;
    }

    public void ProcessMove(Vector3 direction)
    {
        if (direction.sqrMagnitude < DeadZone * DeadZone)
            return;

        _transform.position += direction * _entityData.Speed * Time.deltaTime;

        _transform.forward = direction;
    }
}
