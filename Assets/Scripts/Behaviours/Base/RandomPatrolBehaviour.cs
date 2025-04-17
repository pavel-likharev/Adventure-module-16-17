using UnityEngine;

public class RandomPatrolBehaviour : IEnemyBaseBehaviour
{
    private Vector3 _pointPosition;
    private Enemy _enemy;

    private float _timer;
    private float _patrolTime = 1;
    private float _radiusForPoint = 10;

    private Transform _spawnPoint;

    public RandomPatrolBehaviour(Enemy enemy, Transform spawnPoint)
    {
        _enemy = enemy;
        _spawnPoint = spawnPoint;

        UpdateTarget();
    }

    public void Update()
    {
        _enemy.MoveController.FindCurrentDirection(_pointPosition);

        _timer += Time.deltaTime;

        if (_timer >= _patrolTime)
        {
            _timer = 0;
            UpdateTarget();
        }
    }

    public void UpdateTarget()
    {
        Vector2 randomPoint = Random.insideUnitCircle;
        _pointPosition  = new Vector3(randomPoint.x, 0, randomPoint.y) * _radiusForPoint;
        _pointPosition  = new Vector3(_pointPosition.x + _spawnPoint.position.x, 0, _pointPosition.y + _spawnPoint.position.z);
    }
}