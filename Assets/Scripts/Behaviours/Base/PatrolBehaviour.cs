using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : IEnemyBaseBehaviour
{
    private Enemy _enemy;

    private Transform _currentPoint;
    private Vector3 _pointPosition;

    private Queue<PatrolPoint> _patrolPoints;
    private PatrolPoint _currentoPatrolPoint;

    public PatrolBehaviour(List<PatrolPoint> patrolPoints, Enemy enemy)
    {
        _patrolPoints = new(patrolPoints);
        _enemy = enemy;

        UpdateTarget();
    }

    public void Update()
    {
        _pointPosition = _currentPoint.position;
        _enemy.MoveController.FindCurrentDirection(_pointPosition);

        if (_enemy.MoveController.HasReachedTarget())
            UpdateTarget();
    }

    public void UpdateTarget()
    {
        _currentPoint = GetNewPatrolPoint().transform;
    }

    private PatrolPoint GetNewPatrolPoint()
    {
        _currentoPatrolPoint = _patrolPoints.Dequeue();
        _patrolPoints.Enqueue(_currentoPatrolPoint);
        return _currentoPatrolPoint;
    }
}