using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnTimeOut;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_prefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _spawnTimeOut)
        {
            if (TryGetObject(out GameObject item))
            {
                _elapsedTime = 0;
                int currentSpawnPointNumber = Random.Range(0, _spawnPoints.Length);
                SetObject(item, _spawnPoints[currentSpawnPointNumber].position);
            }
        }
    }

    private void SetObject(GameObject item, Vector3 spawnPosition)
    {
        item.SetActive(true);
        item.transform.position = spawnPosition;
        item.transform.rotation = _prefab.transform.rotation;
    }
}
