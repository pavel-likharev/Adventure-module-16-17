using UnityEngine;

public class RandomPatrolBehaviour : IEnemyBaseBehaviour
{
    private Vector3 _pointPosition;
    private Enemy _enemy;
    private Transform _area;

    private float _timer;
    private float _patrolTime = 2;
    private float _radiusForPoint = 10;

    public RandomPatrolBehaviour(Enemy enemy, Transform area)
    {
        _enemy = enemy;
        _area = area;

        UpdateTarget();
    }

    public void Update()
    {
        _enemy.MoveController.FindCurrentDirection(_pointPosition);

        _timer += Time.deltaTime;

        //Debug.Log(_timer);

        if (_timer >= _patrolTime)
        {
            Debug.Log("reset timer");
            _timer = 0;
            UpdateTarget();
        }
    }

    public void UpdateTarget()
    {
        Vector2 randomPoint = Random.insideUnitCircle;
        _pointPosition  = new Vector3(randomPoint.x, 0, randomPoint.y) * _radiusForPoint;
        Debug.Log("new point " + _pointPosition);
        //_direction = Random.insideUnitCircle;
    }
}