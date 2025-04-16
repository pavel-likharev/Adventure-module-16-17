using UnityEngine;

public class RunAwayBehaviour : IEnemyTriggerBehaviour
{
    private Player _player;
    private Enemy _enemy;

    public RunAwayBehaviour(Player player, Enemy enemy)
    {
        _player = player;
        _enemy = enemy;
    }


    public void Update()
    {
        UpdateTarget();
    }

    public void UpdateTarget()
    {


        Vector3 direction = _player.transform.position;
        _enemy.MoveController.FindCurrentDirection(direction, true);
    }
}
