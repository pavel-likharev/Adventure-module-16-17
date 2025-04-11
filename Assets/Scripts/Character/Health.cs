using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _startHealth;

    [field: SerializeField] public int Value { get; private set; }

    public bool IsDead { get; private set; }

    private void Awake()
    {
        Value = _startHealth;

        IsDead = false;
    }

    public void AddHealth(int value)
    {
        if (value < 0)
        {
            Debug.LogError("Значение не может быть меньше нуля");
            return;
        }

        Value += value;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            Debug.LogError("Урон не может быть меньше нуля");
            return;
        }

        Value -= damage;

        if (Value < 0)
        {
            Value = 0;
            IsDead = true;
        }
    }
}