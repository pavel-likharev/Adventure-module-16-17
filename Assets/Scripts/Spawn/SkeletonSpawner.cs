using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> spawnPoints;

    [SerializeField] private Skeleton skeletonPrefab;

    private void Start()
    {
        foreach (SpawnPoint spawnPoint in spawnPoints)
        {
            Skeleton skeleton = Instantiate(skeletonPrefab, spawnPoint.transform);
        }
    }
}
