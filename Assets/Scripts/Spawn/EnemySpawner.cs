using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    [SerializeField] private List<PatrolPoint> _patrolPoints;

    [SerializeField] private Enemy _skeletonPrefab;

    private void Start()
    {
        foreach (SpawnPoint spawnPoint in _spawnPoints)
        {
            Enemy skeleton = Instantiate(_skeletonPrefab, spawnPoint.transform);
            skeleton.Initialize(new PatrolBehaviour(_patrolPoints, skeleton));
        }
    }
}
