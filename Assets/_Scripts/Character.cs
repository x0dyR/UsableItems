using UnityEngine;

public class Character : MonoBehaviour
{
    private const string VerticalAxis = "Vertical";
    private const string HorizontalAxis = "Horizontal";

    private UsableItem _item;

    public float Speed { get; private set; }

    private void Update()
    {
        Input.GetAxisRaw(VerticalAxis);
        Input.GetAxisRaw(HorizontalAxis);

        if(Input.GetKeyDown(KeyCode.F))
        {
            if (_item == null)
                return;

            _item.Use(this);

            Destroy(_item.gameObject);
            _item = null;
        }
    }
}
