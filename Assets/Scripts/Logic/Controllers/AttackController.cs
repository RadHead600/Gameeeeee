using System.Collections;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Vector3 _triggerSize;
    [SerializeField] private Transform _triggerPos;
    [SerializeField] private LayerMask _enemyMask;

    public bool IsAttack { get; private set; }

    private Coroutine _attackCoroutine;
    private Hand _weaponHand;
    private Weapon _weapon;
    private Collider[] _enemyColldiers;

    private void Awake()
    {
        IsAttack = false;
    }

    public void Shoot()
    {
        if (_attackCoroutine != null)
            return;
        _enemyColldiers = Physics.OverlapBox(_triggerPos.position, _triggerSize, Quaternion.identity, _enemyMask);
        if (_enemyColldiers.Length > 0.5f)
        {
            _attackCoroutine = StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        if (_weapon == null) 
            SetWeapon();
        IsAttack = true;
        yield return new WaitForSeconds(_weapon.TimerBulletDelay);
        if (_weapon is WeaponHands)
            ((WeaponHands)_weapon).EnemyColliders = _enemyColldiers;
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
        Gizmos.DrawWireCube(_triggerPos.position, _triggerSize);
    }
}
