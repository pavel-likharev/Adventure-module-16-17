public class IdleBehaviour : IEnemyBaseBehaviour
{
    private Enemy _enemy;

    public IdleBehaviour(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Update()
    {
        UpdateTarget();
    }

    public void UpdateTarget()
    {
        _enemy.MoveController.FindCurrentDirection(_enemy.transform.position);   
    }
}