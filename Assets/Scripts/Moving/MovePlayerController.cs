using UnityEngine;

public class MovePlayerController : MoveCharacterController
{
    private InputManager _inputManager;
    private CharacterController _characterController;

    public Vector3 Input { get; private set; }

    public override bool IsMoving { get; protected set; }

    protected override void Awake()
    {
        base.Awake();

        _inputManager = GetComponent<InputManager>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (IsMoving = _inputManager.HasInput())
        {
            Input = _inputManager.UserInput;

            MoveTo(Input, _characterController);
            RotateTo(Input);
        }
    }
}