using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : ObjectPool
{
    [SerializeField] private RedBarrel _barrel;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnTimeOut;
    [SerializeField] private bool _isSpawning;

    private void Start()
    {
        Initialize(_barrel.gameObject);
        StartCoroutine(RollBarrel());
    }

    private void SetObject(GameObject item, Vector3 spawnPosition)
    {
        item.SetActive(true);
        item.transform.position = spawnPosition;
        item.transform.rotation = _barrel.transform.rotation;
    }

    private IEnumerator RollBarrel()
    {
        var waitingTime = new WaitForSeconds(_spawnTimeOut);

        while (_isSpawning)
        {
            if (TryGetObject(out GameObject item))
            {
                int currentSpawnPointNumber = Random.Range(0, _spawnPoints.Length);
                SetObject(item, _spawnPoints[currentSpawnPointNumber].position);
                yield return waitingTime;
            }
            else
            {
                yield return null;
            }
        }
    }
}
