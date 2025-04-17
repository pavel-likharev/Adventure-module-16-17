using UnityEngine;
public class AttackBehaviour : IEnemyTriggerBehaviour
{
    private Player _player;
    private Enemy _enemy;

    public AttackBehaviour(Player player, Enemy enemy)
    {
        _player = player;
        _enemy = enemy;
    }

    public void Update()
    {
        Vector3 direction = _player.transform.position;
        _enemy.MoveController.FindCurrentDirection(direction);
    }
}