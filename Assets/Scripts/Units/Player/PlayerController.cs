using UnityEngine;

public class PlayerController : Unit
{
    [SerializeField] private PlayerParameters _playerParameters;

    protected PlayerParameters PlayerParameters => _playerParameters;

    protected virtual void Awake()
    {
        Speed = _playerParameters.Speed;
        HealthPoints = _playerParameters.MinHealthPoints;
    }
}
