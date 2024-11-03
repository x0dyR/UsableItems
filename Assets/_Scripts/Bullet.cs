using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private CapsuleCollider Collider;

    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _destroyTime;

    public void Launch(Vector3 direction)
    {
        _rigidbody.AddForce(direction * _bulletSpeed, ForceMode.Impulse);
        Destroy(gameObject, _destroyTime);
    }

    private void OnCollisionEnter(Collision collision)
        => Destroy(gameObject);
}
