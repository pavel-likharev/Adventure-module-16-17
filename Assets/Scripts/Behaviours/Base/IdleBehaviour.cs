public class IdleBehaviour : IEnemyBaseBehaviour
{
    private Enemy _enemy;

    public IdleBehaviour(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Update()
    {
        _enemy.MoveController.FindCurrentDirection(_enemy.transform.position);
    }
}