using UnityEngine;

public class Inventory
{
    private Transform _itemHandleTransform;

    public Inventory(Transform itemHandleTransform)
    {
        _itemHandleTransform = itemHandleTransform;
    }

    private UsableItem _item;

    public bool HasItem() => _item != null;

    public bool TryGetItem(out UsableItem item)
    {
        if (HasItem() == false)
        {
            item = null;
            return false;
        }

        item = _item;
        return true;
    }

    public void PutItem(UsableItem item)
    {
        if (HasItem())
            return;

        item.transform.SetParent(_itemHandleTransform.transform);
        item.transform.localPosition = Vector3.zero;

        _item = item;
    }
}
