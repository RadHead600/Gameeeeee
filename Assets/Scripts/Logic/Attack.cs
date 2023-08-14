using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    public void Shoot()
    {
        _weapon.Attack();
    }
}
