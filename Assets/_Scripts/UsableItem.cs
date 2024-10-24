using UnityEngine;

public abstract class UsableItem : MonoBehaviour
{
    protected string Name;

    public virtual void Initialize(string name)
    {
        Name = name;
    }


    public virtual void Use(Character character)
        => Debug.Log($"Used {Name} item");
}
