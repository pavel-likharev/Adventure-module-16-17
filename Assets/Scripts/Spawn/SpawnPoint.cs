using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private BaseBehaviours _baseBehaviour;
    [SerializeField] private TriggerBehaviours _triggerBehaviour;

    [SerializeField] private Enemy _skeletonPrefab;

    private SpawnManager _spawnManager;

    private IEnemyBaseBehaviour _enemyBaseBehaviour;
    private IEnemyTriggerBehaviour _enemyTriggerBehaviour;

    public void Inizialize(SpawnManager spawnManager)
    {
        _spawnManager = spawnManager;

        CreateEnemy();
    }

    public void CreateEnemy()
    {
        Enemy skeleton = Instantiate(_skeletonPrefab, transform);

        DetectBaseBehaviour(skeleton);
        DetectTriggerBehaviour(skeleton);

        skeleton.Initialize(_enemyBaseBehaviour, _enemyTriggerBehaviour);
    }

    private void DetectTriggerBehaviour(Enemy skeleton)
    {
        switch (_triggerBehaviour)
        {
            case TriggerBehaviours.Attack:
                _enemyTriggerBehaviour = new AttackBehaviour(_spawnManager.GetPlayer, skeleton);
                break;
            case TriggerBehaviours.RunAway:
                _enemyTriggerBehaviour = new RunAwayBehaviour(_spawnManager.GetPlayer, skeleton);
                break;
            case TriggerBehaviours.Death:
                _enemyTriggerBehaviour = new DeathBehaviour(skeleton);
                break;
        }
    }

    private void DetectBaseBehaviour(Enemy skeleton)
    {
        switch (_baseBehaviour)
        {
            case BaseBehaviours.Idle:
                _enemyBaseBehaviour = new IdleBehaviour(skeleton);
                break;
            case BaseBehaviours.Patrol:
                _enemyBaseBehaviour = new PatrolBehaviour(_spawnManager.GetPatrolPoints, skeleton);
                break;
            case BaseBehaviours.RandomPatrol:
                _enemyBaseBehaviour = new RandomPatrolBehaviour(skeleton, transform);
                break;
        }
    }
}