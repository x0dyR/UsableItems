using UnityEngine;

public class ObjectRotator
{
    private Transform _transform;

    private float _angle;

    public ObjectRotator(Transform transform, float angle)
    {
        _transform = transform;
        _angle = angle;
    }

    public void RotateObject()
    {
        _transform.Rotate(Vector3.up, _angle * Time.deltaTime);
    }
}
