using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [field: SerializeField] public bool IsOccupied { get; private set; }

    public void Occupy(Transform transform)
    {
        transform.SetParent(transform);
        transform.localPosition = Vector3.zero;
        IsOccupied = true;
    }

    public void Release()
        => IsOccupied = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Character _))
            IsOccupied = false;
    }
}
