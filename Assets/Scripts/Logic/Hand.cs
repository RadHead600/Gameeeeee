using UnityEngine;

public class Hand : MonoBehaviour
{
    public Weapon HandWeapon { get; private set; }

    private void Start()
    {
        SetHandWeapon();
    }

    public void SetHandWeapon()
    {
        HandWeapon = GetWeapon();
    }

    public Weapon GetWeapon()
    {
        return GetComponentInChildren<Weapon>();
    }
}
