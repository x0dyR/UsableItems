using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<UsableItem> _items;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    [SerializeField] private float _spawnCooldown;

    private UsableItem _currentItem;
    private SpawnPoint _currentSpawnPoint;

    private float _currentSpawnTime;

    private void Awake()
    {
        _currentSpawnTime = 0;
    }

    private void Update()
    {
        _currentSpawnTime += Time.deltaTime;

        if ((_currentSpawnTime >= _spawnCooldown) == false)
            return;
        
        _currentSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];

        if (_currentSpawnPoint.IsOccupied)
            return;

        _currentItem = Instantiate(_items[Random.Range(0, _items.Count)]);

        _currentSpawnPoint.Occupy(_currentItem.transform);

        _currentItem.transform.SetParent(_currentSpawnPoint.transform);
        _currentItem.transform.localPosition = Vector3.zero;

        _currentSpawnTime = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Character character))
        {
            _currentItem.transform.SetParent(character.transform);
            _currentItem.transform.localPosition = Vector3.zero;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out UsableItem item))
            _currentSpawnPoint.Release();
    }
}
