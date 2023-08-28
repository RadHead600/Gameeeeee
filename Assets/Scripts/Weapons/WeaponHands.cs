using UnityEngine;

public class WeaponHands : Weapon
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _layerMask;

    public override void Attack()
    {
        if (GetUnit())
            GetUnit().TakeDamage(WeaponParameters.AttackDamage);
        TimerBulletDelay = WeaponParameters.AttackDelay;
    }

    private Unit GetUnit()
    {
        Collider[] colliders = Physics.OverlapSphere(PosAttack.transform.position, _attackRadius, _layerMask);
        if (colliders.Length > 0)
            return colliders[0].gameObject.GetComponentInChildren<Unit>();
        return null;
    }
}
