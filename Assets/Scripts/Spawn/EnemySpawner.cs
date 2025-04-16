using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    [SerializeField] private List<PatrolPoint> _patrolPoints;

    [SerializeField] private Enemy _skeletonPrefab;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _area;

    private void Start()
    {
        foreach (SpawnPoint spawnPoint in _spawnPoints)
        {
            Enemy skeleton = Instantiate(_skeletonPrefab, spawnPoint.transform);
            //skeleton.Initialize(new PatrolBehaviour(_patrolPoints, skeleton), new AttackBehaviour(_player, skeleton));
            //skeleton.Initialize(new IdleBehaviour(skeleton), new RunAwayBehaviour(_player, skeleton));
            skeleton.Initialize(new RandomPatrolBehaviour(skeleton, _area), new AttackBehaviour(_player, skeleton)); ;
        }
    }
}
