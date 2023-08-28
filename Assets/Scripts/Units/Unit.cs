using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float Speed { get; set; }

    private int _health;

    public int Health
    {
        get => _health;
        protected set
        {
            _health = value;
            OnHealthChange?.Invoke(_health);
        }
    }

    public event Action<int> OnHealthChange;

    protected virtual void Awake()
    {
        OnHealthChange += (h) => Die(); 
    }

    public virtual void TakeDamage(int amount)
    {
        if (_health - amount < 0)
            return;
        Health -= amount;
    }

    public virtual void AddHealth(int amount)
    {
        Health += amount;
    }

    public virtual void Die()
    {
        if (Health > 0)
            return;
        Destroy(gameObject);
    }
}
