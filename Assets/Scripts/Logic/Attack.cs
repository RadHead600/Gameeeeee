using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _triggerRadius;
    [SerializeField] private LayerMask _enemyMask;

    public static bool IsAttack { get; private set; }

    private Coroutine _attackCoroutine;
    private Hand _weaponHand;
    private Weapon _weapon;

    private void Awake()
    {
        IsAttack = false;
    }

    public void Shoot()
    {
        if (_attackCoroutine == null && Physics.OverlapSphere(transform.position, _triggerRadius, _enemyMask).Length > 0.5f)
        {
            _attackCoroutine = StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        if (_weaponHand == null) 
            SetWeapon();
        IsAttack = true;
        yield return new WaitForSeconds(_weapon.TimerBulletDelay);
        _weapon.Attack();
        IsAttack = false;
        _attackCoroutine = null;
    }

    private void SetWeapon()
    {
        _weaponHand = GetComponentInChildren<Hand>();
        if (_weaponHand.GetWeapon() != null)
            _weapon = _weaponHand.GetWeapon();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _triggerRadius);
    }
}
