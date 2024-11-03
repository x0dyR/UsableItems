using UnityEngine;

public abstract class UsableItem : MonoBehaviour
{
    [SerializeField] protected GameObject VisualModel;
    [field: SerializeField] public ParticleSystem DestroyParticleSystem { get; protected set; }

    public virtual void UseItem(EntityData data)
        => DestroyParticleSystem.Play();
}
