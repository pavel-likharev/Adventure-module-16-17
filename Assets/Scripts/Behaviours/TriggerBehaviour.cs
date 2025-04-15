public class TriggerBehaviour : IEnemyBehaviour
{
    private Player _player;
    private Enemy _enemy;

    public TriggerBehaviour(Player player, Enemy enemy)
    {
        _player = player;
        _enemy = enemy;
    }


    public void Update()
    {
    }

    public void UpdateTarget()
    {
        _enemy.MoveController.SetTarget(_player.transform);
    }
}
