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

    public UsableItem GetItem()
    {
        if (HasItem() == false)
            return null;

        UsableItem selectedItem = _item;
        _item = null;

        return selectedItem;
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
