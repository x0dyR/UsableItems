using UnityEngine;

public class ItemCollector
{
    private Inventory _inventory;

    private Transform _itemHandle;

    public ItemCollector(Inventory inventory)
    {
        _inventory = inventory;
    }

    public void TryCollectItem(Collider collider)
    {
        if (collider.TryGetComponent(out UsableItem item))
        {
            if (_inventory.HasItem() == false)
                _inventory.PutItem(item);
        }
    }
}
