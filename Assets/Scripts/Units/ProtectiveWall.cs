using UnityEngine;

public class ProtectiveWall : Unit
{
    [SerializeField] private UnitParameters _unitParameters;

    protected override void Awake()
    {
        base.Awake();
        Health = _unitParameters.MinHpWall;
    }
}
