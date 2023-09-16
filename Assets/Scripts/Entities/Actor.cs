using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    public int Health => _health;

    [Header("Actor Settings")]
    [SerializeField] private int _health;

    public virtual void TakeDamage(int amount)
    {
        if(amount <= 0) 
            return;

        _health -= amount;
        if(_health <= 0)
            Die();
    }

    public abstract void Die();
}
