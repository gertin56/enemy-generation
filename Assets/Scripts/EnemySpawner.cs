using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Enemy _prefab;

    private SpawnPoint[] spawnPoints;

    private void OnEnable()
    {
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }

    private void Start()
    {
        StartCoroutine(Spawn(_delay));
    }

    private IEnumerator Spawn(float timeInSeconds)
    {
        WaitForSeconds wait = new WaitForSeconds(timeInSeconds);

        while (true)
        {
            int index = Random.Range(0,spawnPoints.Length);
            SpawnPoint spawnPoint = spawnPoints[index];
            Instantiate(_prefab,spawnPoint.transform);
            yield return wait;
        }
    }
}
