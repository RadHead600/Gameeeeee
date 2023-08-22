using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _triggerRadius;

    public static bool IsAttack { get; private set; }

    private Weapon _weapon;
    private Coroutine _attackCoroutine;

    private void Awake()
    {
        IsAttack = false;
    }

    private void Start()
    {
        _weapon = GetComponentInChildren<Weapon>();
    }

    public void Shoot()
    {
        if (_attackCoroutine == null && Physics.OverlapSphere(transform.position, _triggerRadius).Length > 0.5f)
        {
            _attackCoroutine = StartCoroutine(AttackCoroutine());
        }
    }

    private IEnumerator AttackCoroutine()
    {
        if (_weapon == null)
            _weapon = GetComponentsInChildren<Weapon>()[0];
        IsAttack = true;
        yield return new WaitForSeconds(_weapon.TimerBulletDelay);
        if (!_weapon.isActiveAndEnabled)
            yield break;
        _weapon.Attack();
        IsAttack = false;
        _attackCoroutine = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _triggerRadius);
    }
}
