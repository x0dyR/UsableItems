using UnityEngine;

public class SpeedBooster : UsableItem
{
    [field: SerializeField] public int SpeedBoostAmount { get; private set; }

    public override void UseItem(EntityData data)
    {
        data.Speed += SpeedBoostAmount;
        Destroy(gameObject);
    }
}
