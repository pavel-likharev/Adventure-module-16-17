using UnityEngine;

public class MovePlayerController : MoveCharacterController
{
    private InputManager _inputManager;
    private CharacterController _characterController;

    private Vector3 _input;

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
            _input = _inputManager.UserInput;

            MoveTo(_input, _characterController);
            RotateTo(_input);
        }
    }
}