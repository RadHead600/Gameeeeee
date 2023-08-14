using UnityEngine;

public class WeaponHands : Weapon
{
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask _layerMask;

    public override void Attack()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (_timerBulletDelay > 0)
            return;
        if (other.GetComponent<Unit>() != null)
        {
            Collider[] colliders = Physics.OverlapSphere(PosAttack.transform.position, attackRadius, _layerMask);
            if (colliders.Length < 0.6f)
                return;
            other.GetComponent<Unit>().HealthPoints -= WeaponParameters.AttackDamage;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
