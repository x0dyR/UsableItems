using UnityEngine;

public class ItemCollector
{
    private Inventory _inventory;

    private Transform _itemHandle;

    public ItemCollector(Inventory inventory)
    {
        _inventory = inventory;
    }

    public void TryColllectItem(Collider collider)
    {
        Debug.Log(collider);

        if (collider.TryGetComponent(out UsableItem item))
        {
            if (_inventory.HasItem() == false)
            {
                _inventory.PutItem(item);
            }
        }
    }
}
