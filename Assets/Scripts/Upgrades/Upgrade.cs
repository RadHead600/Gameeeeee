using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private UpgradesParameters _upgradesParameters;
    [SerializeField] private Unit _unitUpgrade;

    public object Parameters { get; protected set; }
    public Unit UnitUpgrade => _unitUpgrade;
    public string LastValue { get; set; }
    public int CostUpgrade { get; set; }
    
    // Обязательно переуказать ID апгрейда
    public int UpgradeId { get; set; }

    private void Awake()
    {
        CostUpgrade = _upgradesParameters.MinCost;
        Parameters = _upgradesParameters.Value;
        if (SaveParameters.UpgradesLevel == null)
            SaveParameters.UpgradesLevel = new List<(int, int)>();
    }

    public virtual void Activate()
    {
    }

    protected virtual void SetUpgradeLevel()
    {
        if (SaveParameters.UpgradesLevel.Count < 3)
            SaveParameters.UpgradesLevel.Add((UpgradeId, 1));
    }
}
