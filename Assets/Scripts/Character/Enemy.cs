using UnityEngine;

public class Enemy : Character
{
    private TriggerBehaviour _triggerBehaviour;
    private IEnemyBehaviour _startBehaviour;

    private IEnemyBehaviour _currentBehaviour;

    public MoveEnemyController MoveController { get; private set; }


    private void Start()
    {
        MoveController = GetComponent<MoveEnemyController>();
    }

    public void Initialize(IEnemyBehaviour enemyBehaviour)
    {
        _startBehaviour = enemyBehaviour;
        SetBehaviour(enemyBehaviour);
    }

    public void SetBehaviour(IEnemyBehaviour enemyBehaviour)
    {
        _currentBehaviour = enemyBehaviour;        
    }

    protected override void Update()
    {
        _currentBehaviour.Update();

        base.Update();
    }

    private void UpdateBehaviour(IEnemyBehaviour enemyBehaviour)
    {
        SetBehaviour(enemyBehaviour);
        _currentBehaviour.UpdateTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            if (_triggerBehaviour == null)
                _triggerBehaviour = new TriggerBehaviour(player, this);

            UpdateBehaviour(_triggerBehaviour);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            UpdateBehaviour(_startBehaviour);
        }
    }
}
