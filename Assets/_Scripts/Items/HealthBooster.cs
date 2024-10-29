using UnityEngine;

public class HealthBooster : UsableItem
{
    [field: SerializeField] public int HealthBoostAmount { get; private set; }

    public override void UseItem(EntityData data)
    {
        data.Health += HealthBoostAmount;
        Destroy(gameObject);
    }
}
