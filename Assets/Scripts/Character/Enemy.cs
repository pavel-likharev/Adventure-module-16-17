using UnityEngine;

public class Enemy : Character
{
    private IEnemyTriggerBehaviour _triggerBehaviour;
    private IEnemyBaseBehaviour _baseBehaviour;

    private CapsuleCollider _capsuleCollider;

    private bool _isTriggered;
   
    public MoveEnemyController MoveController { get; private set; }


    private void Start()
    {
        MoveController = GetComponent<MoveEnemyController>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    public void Initialize(IEnemyBaseBehaviour baseBehaviour, IEnemyTriggerBehaviour triggerBehaviour)
    {
        _triggerBehaviour = triggerBehaviour;
        _baseBehaviour = baseBehaviour;
    }

    protected override void Update()
    {
        if (IsDead)
            return;

        if (_isTriggered)
            _triggerBehaviour.Update();
        else
            _baseBehaviour.Update();


        base.Update();
    }

    public override void MakeDeath()
    {
        base.MakeDeath();

        _capsuleCollider.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            _isTriggered = false;
        }
    }
}
