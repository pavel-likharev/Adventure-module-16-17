using UnityEngine;

public class MoveEnemyController : MoveCharacterController
{
    private Vector3 _direction;
    private Vector3 _normalizedDirection;

    private float _minDistanceToTarget = 0.1f;

    public override bool IsMoving { get; protected set; }

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (HasReachedTarget())
        {
            IsMoving = false;
            return;
        }

        MoveTo(_normalizedDirection);
        RotateTo(_normalizedDirection);

        IsMoving = true;
    }

    public void FindCurrentDirection(Vector3 targetPosition, bool isReverse = false)
    {
        _direction = GetDirectionTo(targetPosition, isReverse);
        _normalizedDirection = _direction.normalized;
    }

    public Vector3 GetDirectionTo(Vector3 targetPosition, bool isReverse)
    {
        Vector3 direction;

        if (isReverse)
            direction = transform.position - targetPosition;
        else
            direction = targetPosition - transform.position;

        return new Vector3(direction.x, 0, direction.z);
    }

    public bool HasReachedTarget() => _direction.magnitude <= _minDistanceToTarget;
}