using UnityEngine;

public abstract class MoveCharacterController : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _rotationSpeed;

    public Transform StartPoint { get; private set; }

    public abstract bool IsMoving { get; protected set; }

    protected virtual void Awake()
    {
        StartPoint = transform;
    }

    protected void MoveTo(Vector3 input, CharacterController characterController)
    {
        characterController.Move(input * _moveSpeed * Time.deltaTime);
    }

    protected void MoveTo(Vector3 input)
    {
        transform.Translate(input.normalized * _moveSpeed * Time.deltaTime, Space.World);
    }

    protected void RotateTo(Vector3 input)
    {
        Quaternion lookRotation = Quaternion.LookRotation(input.normalized);
        float step = _rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, step);
    }

    public void ResetPosition() => transform.position = StartPoint.position;
}