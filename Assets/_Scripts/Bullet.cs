using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class Bullet : MonoBehaviour
{
    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }

    [field: SerializeField] public float BulletSpeed { get; private set; }

    [field: SerializeField] public float DestroyTime { get; private set; }

    public CapsuleCollider Collider { get; private set; }

    public void Launch(Vector3 direction)
    {
        Rigidbody.AddForce(direction * BulletSpeed, ForceMode.Impulse);
        Destroy(gameObject, DestroyTime);
    }
}
