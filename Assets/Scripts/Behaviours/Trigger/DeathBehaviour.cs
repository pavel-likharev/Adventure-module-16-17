public class DeathBehaviour : IEnemyTriggerBehaviour
{
    private Enemy _enemy;

    public DeathBehaviour(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Update()
    {
        _enemy.MakeDeath();
        _enemy.MoveController.FindCurrentDirection(_enemy.transform.position);
    }
}