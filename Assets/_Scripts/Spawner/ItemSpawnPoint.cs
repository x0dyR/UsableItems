using UnityEngine;

public class ItemSpawnPoint : MonoBehaviour
{
    private UsableItem _item;

    public void Occupy(UsableItem item) => _item = item;

    public bool IsOccupied() => _item != null;
}
