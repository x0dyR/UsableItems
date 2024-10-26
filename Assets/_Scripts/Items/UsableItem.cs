using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class UsableItem : MonoBehaviour
{
    protected SphereCollider _collider;

    protected ObjectRotator _objectRotator;

    protected virtual void Awake()
    {
        _collider = GetComponent<SphereCollider>();
        _collider.isTrigger = true;
    }

    public abstract CharacterData Use(Character character);

    private void Update()
    {
        _objectRotator.RotateObject();
    }
}
