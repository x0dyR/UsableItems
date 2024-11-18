using UnityEngine;

public abstract class UsableItem : MonoBehaviour
{
    [field: SerializeField] public ParticleSystem DestroyParticleSystem { get; protected set; }

    public virtual void UseItem(EntityData data)
        => Instantiate(DestroyParticleSystem,transform.position,Quaternion.identity,null);
}
