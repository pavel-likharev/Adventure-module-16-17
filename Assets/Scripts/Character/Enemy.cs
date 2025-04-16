using UnityEngine;

public class Enemy : Character
{
    private IEnemyTriggerBehaviour _triggerBehaviour;
    private IEnemyBaseBehaviour _baseBehaviour;

    private bool _isTriggered;

    public MoveEnemyController MoveController { get; private set; }


    private void Start()
    {
        MoveController = GetComponent<MoveEnemyController>();
    }

    public void Initialize(IEnemyBaseBehaviour baseBehaviour, IEnemyTriggerBehaviour triggerBehaviour)
    {
        _triggerBehaviour = triggerBehaviour;
        _baseBehaviour = baseBehaviour;
    }

    protected override void Update()
    {
        if (_isTriggered)
            _triggerBehaviour.Update();
        else
            _baseBehaviour.Update();


        base.Update();
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
            _baseBehaviour.UpdateTarget();
        }
    }
}
