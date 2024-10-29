public class ShootBullet : UsableItem
{
    public override void UseItem(EntityData data)
    {
        Bullet bullet = Instantiate(data.BulletPrefab, data.Transform.position, data.Transform.rotation, null);
        bullet.Launch(data.Transform.forward);
        Destroy(gameObject);
    }
}
