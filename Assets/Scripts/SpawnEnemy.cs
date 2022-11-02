using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private float _spawnTime;
    [SerializeField] private Enemy _prefab;

    private SpawnPoint[] spawnPoints;

    private void OnEnable()
    {
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }

    private void Start()
    {
        StartCoroutine(Spawn(_spawnTime));
    }

    private IEnumerator Spawn(float timeInSeconds)
    {
        while (true)
        {
            int index = Random.Range(0,spawnPoints.Length);
            SpawnPoint spawnPoint = spawnPoints[index];
            Instantiate(_prefab,spawnPoint.transform);
            yield return new WaitForSeconds(timeInSeconds);
        }
    }
}
