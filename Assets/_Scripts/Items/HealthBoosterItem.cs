using UnityEngine;

public class HealthBoosterItem : UsableItem
{
    [SerializeField] private float _angle;
    [field: SerializeField] public int HealthBoostAmoun { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        _objectRotator = new ObjectRotator(transform, _angle);
    }

    public override CharacterData Use(Character character)
    {
        CharacterData newData = new CharacterData(character.Health + HealthBoostAmoun, character.Speed, character.BulletPrefab);
        Debug.Log($"Used {GetType()}");
        return newData;
    }
}
