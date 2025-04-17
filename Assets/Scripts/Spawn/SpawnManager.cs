using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private List<PatrolPoint> _patrolPoints;

    [SerializeField] private Enemy _skeletonPrefab;
    [SerializeField] private Player _player;

    private void Start()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            spawnPoint.Inizialize(this);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Enemy skeleton = Instantiate(_skeletonPrefab, GetRandomSpawnPoint().transform.transform);
            skeleton.Initialize(new IdleBehaviour(skeleton), new DeathBehaviour(skeleton));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Enemy skeleton = Instantiate(_skeletonPrefab, GetRandomSpawnPoint().transform.transform);
            skeleton.Initialize(new PatrolBehaviour(_patrolPoints, skeleton), new AttackBehaviour(_player, skeleton));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnPoint spawnPoint = GetRandomSpawnPoint();
            Enemy skeleton = Instantiate(_skeletonPrefab, spawnPoint.transform);
            skeleton.Initialize(new RandomPatrolBehaviour(skeleton, spawnPoint.transform), new RunAwayBehaviour(_player, skeleton));
        }
    }

    public Player GetPlayer => _player;
    public List<PatrolPoint> GetPatrolPoints => _patrolPoints;

    private SpawnPoint GetRandomSpawnPoint()
    {
        int randomIndexSpawnPoint = Random.Range(0, _spawnPoints.Count);

        return _spawnPoints[randomIndexSpawnPoint];
    }
}