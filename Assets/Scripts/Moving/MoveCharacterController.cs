using UnityEngine;

public abstract class MoveCharacterController : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _rotationSpeed;

    protected Vector3 _startPosition;

    public abstract bool IsMoving { get; protected set; }

    protected virtual void Awake()
    {
        _startPosition = transform.position;
    }

    public void BoostSpeed(float value)
    {
        if (value < 0)
        {
            Debug.LogError("«начение увеличени€ скорости не может быть меньше 0");
            return;
        }

        _moveSpeed += value;
    }

    protected void MoveTo(Vector3 input, CharacterController characterController)
    {
        characterController.Move(input * _moveSpeed * Time.deltaTime);


    }

    protected void MoveTo(Vector3 input)
    {
        transform.Translate(input.normalized * _moveSpeed * Time.deltaTime, Space.World);

        Debug.DrawRay(transform.position, input, Color.magenta);
    }

    protected void RotateTo(Vector3 input)
    {
        Quaternion lookRotation = Quaternion.LookRotation(input.normalized);
        float step = _rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, step);
    }

    public void ResetPosition() => transform.position = _startPosition;
}