using UnityEngine;

public class HealthBooster : UsableItem
{
    [SerializeField] private int _healthBoostAmount;

    public override void UseItem(EntityData data)
    {
        base.UseItem(data);

        data.Health += _healthBoostAmount;

        Destroy(gameObject);
    }
}
