using UnityEngine;

public class MoveEnemyController : MoveCharacterController
{
    [SerializeField] private float _minDistanceToPlayer = 3;
    private float _minDistanceToStartPoint = 0.05f;

    private Vector3 _direction;
    private Vector3 _normalizedDirection;

    private Transform _target;


    public override bool IsMoving { get; protected set; }

    [SerializeField] private bool _isAttacking;

    protected override void Awake()
    {
        base.Awake();

        IsMoving = false;
        //_direction = GetDirectionTo(_startPosition);
    }

    private void Update()
    {
        if (_isAttacking == false)
        {
            ReturnToStartPoint();
            return;
        }

        FindCurrentDirection(_target.position);

        MoveTo(_normalizedDirection);
        RotateTo(_normalizedDirection);

        //
    }

    private void ReturnToStartPoint()
    {

        if (IsMoving == false)
            return;
        Debug.Log("move to start point");

        FindCurrentDirection(_startPosition);

        MoveTo(_normalizedDirection);
        RotateTo(_normalizedDirection);

        if (_direction.magnitude <= _minDistanceToStartPoint)
        {
            Debug.Log("start point");
            IsMoving = false;
        }
    }

    private void FindCurrentDirection(Vector3 targetPosition)
    {
        _direction = GetDirectionTo(targetPosition);

        if (_direction.magnitude > _minDistanceToPlayer)
        {
            _direction = GetDirectionTo(_startPosition);
            _isAttacking = false;
        }

        _normalizedDirection = _direction.normalized;
    }

    private Vector3 GetDirectionTo(Vector3 target)
    {
        Vector3 direction = target - transform.position;

        return new Vector3(direction.x, 0, direction.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _target = player.transform;
            _isAttacking = true;
            IsMoving = true;
            //targetPosition = player.transform;
        }
    }
}
