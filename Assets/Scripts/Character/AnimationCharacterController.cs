using UnityEngine;

public class AnimationCharacterController : MonoBehaviour
{
    private const string RunningKey = "IsRunning";
    private const string AttackingKey = "IsAttacking";
    private const string DeadKey = "Dead";
    private const string WinKey = "Win";
    private const string RestartKey = "Restart";

    private Animator _animator;

    public bool IsMoving { get; set; }
    public bool IsAttacking { get; set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(RunningKey, IsMoving);
    }

    public void StartDeathClip() => _animator.SetTrigger(DeadKey);
    public void StartWinClip() => _animator.SetTrigger(WinKey);
    public void Restart() => _animator.SetTrigger(RestartKey);
}