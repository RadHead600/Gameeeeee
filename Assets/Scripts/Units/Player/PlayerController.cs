using UnityEngine;

public class PlayerController : Unit
{
    [SerializeField] private PlayerParameters _playerParameters;

    protected PlayerParameters PlayerParameters => _playerParameters;

    protected override void Awake()
    {
        base.Awake();
        Speed = _playerParameters.Speed;
        Health = _playerParameters.MinHealthPoints;
    }
}
