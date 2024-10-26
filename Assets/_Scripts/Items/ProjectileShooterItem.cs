using UnityEngine;

public class ProjectileShooterItem : UsableItem
{
    [SerializeField] private float _angle;

    private Character _character;

    protected override void Awake()
    {
        base.Awake();

        _objectRotator = new ObjectRotator(transform, _angle);
    }

    public override CharacterData Use(Character character)
    {
        _character = character;

        Shoot(_character.CharacterData.BulletPrefab);
        return _character.CharacterData;
    }

    private void Shoot(Bullet bullet)
    {
        Bullet newBullet = Instantiate(bullet, _character.ShootPoint.position, _character.ShootPoint.rotation);
        Debug.Log($"Used {GetType()}");
        newBullet.Launch(_character.ShootPoint.forward);
    }
}
