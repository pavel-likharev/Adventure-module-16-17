using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected AnimationCharacterController _animationCharacter;
    protected MoveCharacterController _moveController;

    protected Health _health;

    protected virtual void Awake()
    {
        _health = GetComponent<Health>();
        _animationCharacter = GetComponent<AnimationCharacterController>();
        _moveController = GetComponent<MoveCharacterController>();
    }

    protected virtual void Update()
    {
        Animate();
    }

    private void Animate()
    {
        _animationCharacter.IsMoving = _moveController.IsMoving;
    }

    public virtual void Reset()
    {
        _moveController.ResetPosition();
        _animationCharacter.Restart();
    }

    public void MakeLoser() => _animationCharacter.StartDeathClip();

    public void MakeWinner() => _animationCharacter.StartWinClip();
}