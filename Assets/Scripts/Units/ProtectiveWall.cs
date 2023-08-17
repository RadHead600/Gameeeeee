using System.Diagnostics;
using UnityEngine;

public class ProtectiveWall : Unit
{
    [SerializeField] private UnitParameters _unitParameters;

    private void Awake()
    {
        HealthPoints = _unitParameters.MinHpWall;
    }

    public override void Die()
    {
        if (HealthPoints <= 0)
            Destroy(gameObject);
    }
}
