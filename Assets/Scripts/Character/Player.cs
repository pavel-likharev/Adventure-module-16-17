using UnityEngine;

public class Player : Character
{
    public MovePlayerController MoveController { get; private set; }

    private void Start()
    {
        MoveController = GetComponent<MovePlayerController>();
    }
}