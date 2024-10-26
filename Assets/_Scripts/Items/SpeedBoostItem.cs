using UnityEngine;

public class SpeedBoostItem : UsableItem
{
    [SerializeField] private float _angle;
    [field: SerializeField] public int SpeedBoostAmount { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        _objectRotator = new ObjectRotator(transform, _angle);
    }

    public override CharacterData Use(Character character)
    {
        CharacterData newData = new CharacterData(character.Health, character.Speed + SpeedBoostAmount, character.BulletPrefab);
        Debug.Log($"Used {GetType()}");
        return newData;
    }
}
