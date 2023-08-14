using System;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private UpgradesParameters _upgradesParameters;

    protected UpgradesParameters UpgradesParameters => _upgradesParameters;
    public object Parameters { get; protected set; }

    private void Start()
    {
        SetParameters();
    }

    public void SetParameters()
    {
        Parameters = UnityEngine.Random.Range(UpgradesParameters.MinValue, UpgradesParameters.MaxValue);
    }

    public virtual void Activate(Unit unit)
    {
        throw new Exception("Activation is not set!");
    }
}
