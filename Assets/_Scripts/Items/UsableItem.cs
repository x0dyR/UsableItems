using UnityEngine;

public abstract class UsableItem : MonoBehaviour
{
    [SerializeField] protected ParticleSystem _destParticleSystem;

    public virtual void UseItem(EntityData data)
    {
        _destParticleSystem.Play();
    }

    public ParticleSystem DestParticleSystem => _destParticleSystem;
}
