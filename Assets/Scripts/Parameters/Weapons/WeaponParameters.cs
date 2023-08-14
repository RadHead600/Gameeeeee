using UnityEngine;

public class WeaponParameters : ScriptableObject
{
    [SerializeField] private string _weaponName;
    [SerializeField] private int _cost;
    [SerializeField] private Sprite _weaponSprite;

    [SerializeField] private int _attackDamage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackDelay;
    [SerializeField] private Bullet _bullet;

    public string WeaponName => _weaponName;
    public int Cost => _cost;
    public Sprite WeaponSprite => _weaponSprite;

    public int AttackDamage => _attackDamage;
    public float AttackSpeed => _attackSpeed;
    public float AttackDelay => _attackDelay;
    public Bullet Bullet => _bullet;
}