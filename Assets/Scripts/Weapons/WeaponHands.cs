using UnityEngine;

public class WeaponHands : Weapon
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _layerMask;

    public override void Attack()
    {
        if (GetUnit())
            GetUnit().HealthPoints -= WeaponParameters.AttackDamage;
        TimerBulletDelay = WeaponParameters.AttackDelay;
    }

    private Unit GetUnit()
    {
        Collider[] colliders = Physics.OverlapSphere(PosAttack.transform.position, _attackRadius, _layerMask);
        if (colliders.Length < 1)
            return null;
        if (colliders[0].gameObject.GetComponentInChildren<Unit>() == null)
            return null;
        return colliders[0].gameObject.GetComponentInChildren<Unit>();
    }
}
