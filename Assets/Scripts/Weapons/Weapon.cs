using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponParameters _weaponParameters;
    [SerializeField] private GameObject _posAttack;

    protected WeaponParameters WeaponParameters => _weaponParameters;
    protected GameObject PosAttack => _posAttack;
    protected float _timerBulletDelay;

    private void Update()
    {
        if (_timerBulletDelay > 0)
        {
            _timerBulletDelay -= Time.deltaTime;
        }
    }

    public virtual void Attack()
    {
        if (_timerBulletDelay > 0)
            return;
        Shot();
    }
    
    public void Shot()
    {
        try
        {
            if (_weaponParameters.Bullet == null)
            {
            }
        }
        catch
        {
            return;
        }

        Bullet newBullet = Instantiate(_weaponParameters.Bullet, _posAttack.transform.position, _posAttack.transform.rotation);

        newBullet.Speed = _weaponParameters.AttackSpeed;
        newBullet.Damage = _weaponParameters.AttackDamage;
        _timerBulletDelay = _weaponParameters.AttackDelay;
    }
}
