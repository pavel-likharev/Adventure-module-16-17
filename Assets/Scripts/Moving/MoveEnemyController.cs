using UnityEngine;

public class MoveEnemyController : MoveCharacterController
{
    private Vector3 _direction;
    private Vector3 _normalizedDirection;
    private Transform _target;

    private float _minDistanceToTarget = 0.1f;

    public override bool IsMoving { get; protected set; }

    protected override void Awake()
    {
        base.Awake();

        SetTarget(StartPoint);
    }

    private void Update()
    {
        FindCurrentDirection(_target.position);

        if (HasReachedTarget())
        {
            IsMoving = false;
            return;
        }

        MoveTo(_normalizedDirection);
        RotateTo(_normalizedDirection);

        IsMoving = true;
    }

    public void ReturnToBaseBahaviour() => SetTarget(StartPoint);

    public void SetTarget(Transform target) => _target = target;

    private void FindCurrentDirection(Vector3 targetPosition)
    {
        _direction = GetDirectionTo(targetPosition);

        _normalizedDirection = _direction.normalized;
    }

    private Vector3 GetDirectionTo(Vector3 target)
    {
        Vector3 direction = target - transform.position;

        return new Vector3(direction.x, 0, direction.z);
    }

    public bool HasReachedTarget() => _direction.magnitude <= _minDistanceToTarget;


}
