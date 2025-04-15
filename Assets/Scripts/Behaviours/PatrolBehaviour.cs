using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : IEnemyBehaviour
{
    private Enemy _enemy;

    private Queue<PatrolPoint> _patrolPoints;
    private PatrolPoint _currentoPatrolPoint;

    public PatrolBehaviour(List<PatrolPoint> patrolPoints, Enemy enemy)
    {
        _patrolPoints = new(patrolPoints);
        _enemy = enemy;
    }

    public void Update()
    {
        if (_enemy.MoveController.HasReachedTarget())
            _enemy.MoveController.SetTarget(GetNewPatrolPoint().transform);
    }

    private PatrolPoint GetNewPatrolPoint()
    {
        _currentoPatrolPoint = _patrolPoints.Dequeue();
        _patrolPoints.Enqueue(_currentoPatrolPoint);
        return _currentoPatrolPoint;
    }

    public void UpdateTarget()
    {
        _enemy.MoveController.SetTarget(GetNewPatrolPoint().transform);
    }
}
