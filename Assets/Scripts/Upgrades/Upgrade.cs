using System;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private UpgradesParameters _upgradesParameters;
    [SerializeField] private Unit _unitUpgrade;

    protected UpgradesParameters UpgradesParameters => _upgradesParameters;
    public object Parameters { get; protected set; }
    public Unit UnitUpgrade => _unitUpgrade;
    public string LastValue { get; set; }

    private void Start()
    {
        SetRandomParameters();
    }

    public void SetRandomParameters()
    {
        Parameters = Math.Round(UnityEngine.Random.Range(UpgradesParameters.MinValue, UpgradesParameters.MaxValue), 2);
    }

    public virtual void Activate()
    {
        throw new Exception("Activation is not set!");
    }
}
