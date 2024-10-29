using UnityEngine;

public class ShootBullet : UsableItem
{
    [field: SerializeField] private Bullet _bulletPrefab;

    public override void UseItem(EntityData data)
    {
        Bullet instance = Instantiate(_bulletPrefab, data.Transform.position, data.Transform.rotation, null);
        instance.Launch(data.Transform.forward);
        Destroy(gameObject);
    }
}
