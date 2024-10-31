using UnityEngine;

public class ShootBullet : UsableItem
{
    [SerializeField] private Bullet _bulletPrefab;

    public override void UseItem(EntityData data)
    {
        base.UseItem(data);

        Bullet bullet = Instantiate(_bulletPrefab, data.Transform.position, data.Transform.rotation, null);
        bullet.Launch(data.Transform.forward);
        Destroy(gameObject, _destParticleSystem.main.duration);
    }
}
