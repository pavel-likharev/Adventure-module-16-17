using UnityEngine;

public class InputManager : MonoBehaviour
{
    private const string HorizontalInputKey = "Horizontal";
    private const string VerticalInputKey = "Vertical";
    
    private float _moveDeadZone = 0.1f;

    public Vector3 UserInput { get; private set; }

    public bool IsPressedUseItemKey { get; private set; }

    private void Update()
    {
        UserInput = GetUserInput();
    }

    public void ResetUseKeyKey() => IsPressedUseItemKey = false;

    public bool HasInput() => UserInput.magnitude > _moveDeadZone;

    public Vector3 GetUserInput() => new Vector3(Input.GetAxisRaw(HorizontalInputKey), 0, Input.GetAxisRaw(VerticalInputKey));
}