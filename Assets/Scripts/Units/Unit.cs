using UnityEngine;

public class Unit : MonoBehaviour
{
    public float Speed { get; set; }
    public int HealthPoints { get; set; }

    public virtual int ReceiveDamage(int damage)
    {
        HealthPoints -= damage;
        Die();
        return HealthPoints;
    }

    public virtual void Die()
    {
        if (HealthPoints <= 0)
            Destroy(gameObject);
    }
}
