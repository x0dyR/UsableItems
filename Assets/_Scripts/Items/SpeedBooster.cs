using UnityEngine;

public class SpeedBooster : UsableItem
{
    [SerializeField] private int _speedBoostAmount;

    public override void UseItem(EntityData data)
    {
        base.UseItem(data);

        data.Speed += _speedBoostAmount;
        Destroy(gameObject, _destParticleSystem.main.duration);
    }
}
