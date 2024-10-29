using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<ItemSpawnPoint> _spawnPoints;
    [SerializeField] private List<UsableItem> _itemPrefabs;

    [SerializeField] private float _spawnTime;

    private float _currentTime;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _spawnTime)
        {
            ItemSpawnPoint spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];

            if (spawnPoint.IsOccupied())
                return;

            UsableItem item = Instantiate(_itemPrefabs[Random.Range(0, _itemPrefabs.Count)],
                spawnPoint.transform.position, spawnPoint.transform.rotation, spawnPoint.transform);

            spawnPoint.Occupy(item);
            _currentTime = 0;
        }
    }
}
